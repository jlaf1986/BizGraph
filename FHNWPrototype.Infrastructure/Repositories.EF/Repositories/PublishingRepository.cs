using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Publishing.Tweets;
using FHNWPrototype.Domain.Notifications;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class PublishingRepository
    {
        
        public static ContentStream GetContentStreamAsProfileWall(Guid OwnerKey)
        {
           // var result = null;
            using (var db = new FHNWPrototypeDB())
            {
                ContentStream result = db.ContentStreams
                              .Include("Posts.Author")
                              .Include("Posts.PostLikes.Author")
                              .Include("Posts.Comments.Author")
                              .Include("Posts.Comments.CommentLikes.Author")
                              .Include("Tweets.Author")
                              .Include("Retweets.Author")
                              .Include("Retweets.Tweet.Author")
                              .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey);

                if (result == null)
                {
                    result = new ContentStream();
                    result.Posts = new List<Post>();
                    result.Tweets = new List<Tweet>();
                    result.Retweets = new List<Retweet>();
                }
                else
                {

                    if (result.Posts == null) result.Posts = new List<Post>();
                    if (result.Tweets == null) result.Tweets = new List<Tweet>();
                    if (result.Retweets == null) result.Retweets = new List<Retweet>();


                    var newPostList = result.Posts.OrderByDescending(x => x.PublishDateTime).Take(3).ToList();
                    foreach (var post in newPostList)
                    {
                        var newCommentList = post.Comments.OrderBy(x => x.PublishDateTime).ToList();
                        post.Comments = newCommentList;
                    }
                    result.Posts = newPostList;

                    var newTweetList = result.Tweets.OrderByDescending(x => x.PublishDateTime).Take(3).ToList();

                    result.Tweets = newTweetList;

                    var newRetweetList = result.Retweets.OrderByDescending(x => x.PublishDateTime).Take(3).ToList();

                    result.Retweets = newRetweetList;
                }
              

                

                return result;
            }
          
        }

        public static ContentStream GetContentStreamAsNewsfeed(Guid OwnerKey)
        {
            ContentStream newsfeed  = new ContentStream();
            newsfeed.Posts = new List<Post>();
            newsfeed.Tweets = new List<Tweet>();
            newsfeed.Retweets = new List<Retweet>();

            //used when the viewer is a user account
            List<Post> postsFromMyEmployer = new List<Post>();
            List<Tweet> tweetsFromEmployer = new List<Tweet>();
            List<Retweet> retweetsFromEmployer = new List<Retweet>();

            List<Post> postsToMe = new List<Post>();

            List<Post> postsFromPeersReceived = new List<Post>();
            List<Post> postsFromPeersRequested = new List<Post>();

            List<Tweet> tweetsToMe = new List<Tweet>();

            List<Tweet> tweetsFromPeersReceived = new List<Tweet>();
            List<Tweet> tweetsFromPeersRequested = new List<Tweet>();

            List<Retweet> retweetsFromMe = new List<Retweet>();
            List<Retweet> retweetsFromPeersReceived = new List<Retweet>();
            List<Retweet> retweetsFromPeersRequested = new List<Retweet>();

            List<Post> allPostsFromNewsfeed = new List<Post>();

            List<Tweet> allTweetsFromNewsfeed = new List<Tweet>();

            List<Retweet> allRetweetsFromNewsfeed = new List<Retweet>();

            using (var db = new FHNWPrototypeDB())
            {
                //db.Configuration.LazyLoadingEnabled = false;

                newsfeed.Owner = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == OwnerKey);



                if (newsfeed.Owner.ReferenceType == Domain._Base.Accounts.AccountType.UserAccount)
                {
                    var owner = db.UserAccounts
                                            .Include("FriendshipsReceived.Sender")
                                            .Include("FriendshipsRequested.Receiver")
                                            .FirstOrDefault(x => x.Key == OwnerKey);


                    var employer = db.UserAccounts
                                            .Include("OrganizationAccount")
                                            .FirstOrDefault(x=> x.Key==owner.Key)
                                            .OrganizationAccount.Key;

                    var anyPostsOnMyEmployersWall = db.ContentStreams
                                                    .Include("Owner")
                                                    .Include("Posts.Author")
                                                    .Include("Posts.PostLikes.Author")
                                                    .Include("Posts.Comments.Author")
                                                    .Include("Posts.Comments.CommentLikes.Author")
                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == employer)
                                                    .Posts
                                                    .OrderByDescending(y=>y.PublishDateTime)
                                                    .ToList();

                    if (anyPostsOnMyEmployersWall != null) postsFromMyEmployer.AddRange(anyPostsOnMyEmployersWall);


                    var anyPostsOnMyWall = db.ContentStreams
                                                .Include("Owner")
                                                .Include("Posts.Author")
                                                .Include("Posts.PostLikes.Author")
                                                .Include("Posts.Comments.Author")
                                                .Include("Posts.Comments.CommentLikes.Author")
                                                .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey)
                                                .Posts 
                                                .OrderByDescending(y => y.PublishDateTime)
                                                .ToList();


                    if (anyPostsOnMyWall != null) postsToMe.AddRange(anyPostsOnMyWall);

              


                    var tweetsOnMyEmployerWall = db.ContentStreams
                                                 .Include("Owner")
                                                 .Include("Tweets.Author")
                                                 .FirstOrDefault(x => x.Owner.ReferenceKey == employer)
                                                 .Tweets.Where(x => x.Author.ReferenceKey == employer)
                                                 .OrderByDescending(y => y.PublishDateTime)
                                                 .ToList();

                    if (tweetsOnMyEmployerWall != null) tweetsFromEmployer.AddRange(tweetsOnMyEmployerWall);

                    var tweetsFromMyWall = db.ContentStreams
                                                            .Include("Owner")
                                                            .Include("Tweets.Author")
                                                            .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey )
                                                            .Tweets.Where(x => x.Author.ReferenceKey == OwnerKey )
                                                            .OrderByDescending(y => y.PublishDateTime)
                                                            .ToList();

                    if (tweetsFromMyWall != null) tweetsToMe.AddRange(tweetsFromMyWall);


                    var retweetsFromMyEmployerWall = db.ContentStreams
                                               .Include("Owner")
                                               .Include("Retweets.Author")
                                               .Include("Retweets.Tweet.Author")
                                               .FirstOrDefault(x => x.Owner.ReferenceKey == employer)
                                               .Retweets.Where(x => x.Author.ReferenceKey == employer)
                                               .OrderByDescending(y => y.PublishDateTime)
                                               .ToList();

                    if (retweetsFromMyEmployerWall != null) retweetsFromEmployer.AddRange(retweetsFromMyEmployerWall);

                    var retweetsFromMyWall = db.ContentStreams
                                                            .Include("Owner")
                                                            .Include("Retweets.Author")
                                                            .Include("Retweets.Tweet.Author")
                                                            .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey )
                                                            .Retweets.Where(x => x.Author.ReferenceKey == OwnerKey )
                                                            .OrderByDescending(y => y.PublishDateTime)
                                                            .ToList();

                    if (retweetsFromMyWall != null) retweetsFromMe.AddRange(retweetsFromMyWall);



                    foreach (FriendshipStateInfo friendship in owner.FriendshipsReceived)
                    {
                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x=>x.ReferenceKey==friendship.Sender.Key);


                        var postsFromWallOfReceived=  db.ContentStreams
                                                            .Include("Owner")
                                                           .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                          
                                                             .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Sender.Key)
                                                             
                                                            .Posts.Where(x => x.Author.ReferenceKey == friendship.Sender.Key)
                                                             .OrderByDescending(y => y.PublishDateTime)
                                                             .ToList();

                        if (postsFromWallOfReceived != null) postsFromPeersReceived.AddRange(postsFromWallOfReceived);

                        var tweetsFromWallOfReceived = db.ContentStreams
                                                             .Include("Owner")
                                                           .Include("Tweets.Author")
                                                              .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Sender.Key)

                                                             .Tweets.Where(x => x.Author.ReferenceKey == friendship.Sender.Key)
                                                              .OrderByDescending(y => y.PublishDateTime)
                                                              .ToList();

                        if (tweetsFromWallOfReceived != null) tweetsFromPeersReceived.AddRange(tweetsFromWallOfReceived);


                        var retweetsFromWallOfReceived = db.ContentStreams
                                                             .Include("Owner")
                                                           .Include("Retweets.Author")
                                                             .Include("Retweets.Tweet.Author")
                                                              .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Sender.Key)

                                                             .Retweets.Where(x => x.Author.ReferenceKey == friendship.Sender.Key)
                                                              .OrderByDescending(y => y.PublishDateTime)
                                                              .ToList();

                        if (retweetsFromWallOfReceived != null) retweetsFromPeersReceived.AddRange(retweetsFromWallOfReceived);


                    }

                    foreach (FriendshipStateInfo friendship in owner.FriendshipsRequested)
                    {
                      //  var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == friendship.Receiver.Key);

                        var postFromWallRequested = db.ContentStreams
                                                                    .Include("Owner")
                                                                      .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Receiver.Key)
                                                                     .Posts.Where(x => x.Author.ReferenceKey == friendship.Receiver.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .ToList();

                        if (postFromWallRequested != null) postsFromPeersRequested.AddRange(postFromWallRequested);


                        var tweetsFromWallRequested = db.ContentStreams
                                                                  .Include("Owner")
                                                                    .Include("Tweets.Author")
                                                     
                                                                  .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Receiver.Key)
                                                                   .Tweets.Where(x => x.Author.ReferenceKey == friendship.Receiver.Key)
                                                                  .OrderByDescending(y => y.PublishDateTime)
                                                                  .ToList();

                        if (tweetsFromWallRequested != null) tweetsFromPeersRequested.AddRange(tweetsFromWallRequested);


                        var retweetsFromWallRequested = db.ContentStreams
                                                              .Include("Owner")
                                                                .Include("Retweets.Author")
                                                                .Include("Retweets.Tweet.Author")
                                                              .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Receiver.Key)
                                                               .Retweets.Where(x => x.Author.ReferenceKey == friendship.Receiver.Key)
                                                              .OrderByDescending(y => y.PublishDateTime)
                                                              .ToList();

                        if (retweetsFromWallRequested != null) retweetsFromPeersRequested.AddRange(retweetsFromWallRequested);


                    }

                }

                if (newsfeed.Owner.ReferenceType == AccountType.OrganizationAccount)
                {
                    var owner = db.OrganizationAccounts
                                                    .Include("PartnershipsReceived.Sender")
                                                    .Include("PartnershipsRequested.Receiver")
                                                    .FirstOrDefault(x => x.Key == OwnerKey);

                    var postsFromMyWall = db.ContentStreams
                                               .Include("Owner")
                                               .Include("Posts.Author")
                                               .Include("Posts.PostLikes.Author")
                                               .Include("Posts.Comments.Author")
                                               .Include("Posts.Comments.CommentLikes.Author")
                                               .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey)
                                               .Posts
                                               .OrderByDescending(y => y.PublishDateTime)
                                               .ToList();


                    if (postsFromMyWall != null) postsToMe.AddRange(postsFromMyWall);

                    var tweetsFromMyWall = db.ContentStreams
                                                       .Include("Owner")
                                                     .Include("Tweets.Author")
                                                        .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey)

                                                       .Tweets
                                                        .OrderByDescending(y => y.PublishDateTime)
                                                        .ToList();

                    if (tweetsFromMyWall != null) tweetsToMe.AddRange(tweetsFromMyWall);


                    var retweetsFromMyWall = db.ContentStreams
                                                         .Include("Owner")
                                                       .Include("Retweets.Author")
                                                       .Include("Retweets.Tweet.Author")
                                                          .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey)

                                                         .Retweets.Where(x => x.Author.ReferenceKey == OwnerKey)
                                                          .OrderByDescending(y => y.PublishDateTime)
                                                          .ToList();

                    if (retweetsFromMyWall != null) retweetsFromMe.AddRange(retweetsFromMyWall);
                     
                    foreach (PartnershipStateInfo partnership in owner.PartnershipsReceived)
                    {

                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == partnership.Sender.Key);

                        var postsfromWallOfReceived = db.ContentStreams
                                                                    .Include("Owner")
                                                                    .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Sender.Key)
                                                                    .Posts.Where(x => x.Author.ReferenceKey == partnership.Sender.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .ToList();

                        if (postsfromWallOfReceived != null) postsFromPeersReceived.AddRange(postsfromWallOfReceived);


                        var tweetsfromWallOfReceived = db.ContentStreams
                                                                  .Include("Owner")
                                                                  .Include("Tweets.Author")
                                                
                                                                  .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Sender.Key)
                                                                  .Tweets.Where(x => x.Author.ReferenceKey == partnership.Sender.Key)
                                                                  .OrderByDescending(y => y.PublishDateTime)
                                                                  .ToList();

                        if (tweetsfromWallOfReceived != null) tweetsFromPeersReceived.AddRange(tweetsfromWallOfReceived);

                        var retweetsfromWallOfReceived = db.ContentStreams
                                                                .Include("Owner")
                                                                .Include("Retweets.Author")
                                                                .Include("Retweets.Tweet.Author")
                                                                .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Sender.Key)
                                                                .Retweets.Where(x => x.Author.ReferenceKey == partnership.Sender.Key)
                                                                .OrderByDescending(y => y.PublishDateTime)
                                                                .ToList();

                        if (retweetsfromWallOfReceived != null) retweetsFromPeersReceived.AddRange(retweetsfromWallOfReceived);


                    }

                    foreach (PartnershipStateInfo partnership in owner.PartnershipsRequested)
                    {
                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == partnership.Receiver.Key);

                        //var temp = db.ContentStreams
                        //                                              .Include("Owner")
                        //                                              .Include("Posts.Author")
                        //                                              .Include("Posts.PostLikes.Author")
                        //                                              .Include("Posts.Comments.Author")
                        //                                              .Include("Posts.Comments.CommentLikes.Author")
                        //                                            .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Receiver.Key)
                        //                                            .Posts.Where(x => x.Author.ReferenceKey == partnership.Receiver.Key)
                        //                                            .OrderByDescending(y => y.PublishDateTime)
                        //                                            .Take(3).ToList();

                        //if (temp != null) postsFromPeersRequested.AddRange(temp);


                        var postFromWallRequested = db.ContentStreams
                                                                    .Include("Owner")
                                                                    .Include("Posts.Author")
                                                                    .Include("Posts.PostLikes.Author")
                                                                    .Include("Posts.Comments.Author")
                                                                    .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Receiver.Key)
                                                                    .Posts.Where(x => x.Author.ReferenceKey == partnership.Receiver.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .ToList();

                        if (postFromWallRequested != null) postsFromPeersRequested.AddRange(postFromWallRequested);


                        var tweetsFromWallRequested = db.ContentStreams
                                                                  .Include("Owner")
                                                                  .Include("Tweets.Author")
                                                                  .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Receiver.Key)
                                                                  .Tweets.Where(x => x.Author.ReferenceKey == partnership.Receiver.Key)
                                                                  .OrderByDescending(y => y.PublishDateTime)
                                                                  .ToList();

                        if (tweetsFromWallRequested != null) tweetsFromPeersRequested.AddRange(tweetsFromWallRequested);


                        var retweetsFromWallRequested = db.ContentStreams
                                                                .Include("Owner")
                                                                .Include("Retweets.Author")
                                                                .Include("Retweets.Tweet.Author")
                                                                .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Receiver.Key)
                                                                .Retweets.Where(x => x.Author.ReferenceKey == partnership.Receiver.Key)
                                                                .OrderByDescending(y => y.PublishDateTime)
                                                                .ToList();

                        if (retweetsFromWallRequested != null) retweetsFromPeersRequested.AddRange(retweetsFromWallRequested);


                    }

                }

                if (postsToMe != null) newsfeed.Posts = newsfeed.Posts.Union(postsToMe).ToList();

                if (postsFromMyEmployer != null) newsfeed.Posts = newsfeed.Posts.Union(postsFromMyEmployer).ToList();

                if (postsFromPeersReceived != null) newsfeed.Posts= newsfeed.Posts.Union(postsFromPeersReceived).ToList();

                if (postsFromPeersRequested != null) newsfeed.Posts = newsfeed.Posts.Union(postsFromPeersRequested).ToList();

                newsfeed.Posts = newsfeed.Posts.OrderByDescending(x => x.PublishDateTime).ToList();


                if (tweetsToMe != null) newsfeed.Tweets= newsfeed.Tweets.Union(tweetsToMe).ToList();

                if (tweetsFromEmployer != null) newsfeed.Tweets = newsfeed.Tweets.Union(tweetsFromEmployer).ToList();

                if (tweetsFromPeersReceived != null) newsfeed.Tweets = newsfeed.Tweets.Union(tweetsFromPeersReceived).ToList();

                if (tweetsFromPeersRequested != null) newsfeed.Tweets = newsfeed.Tweets.Union(tweetsFromPeersRequested).ToList();

                newsfeed.Tweets = newsfeed.Tweets.OrderByDescending(x => x.PublishDateTime).ToList();


                if (retweetsFromMe != null) newsfeed.Retweets= newsfeed.Retweets.Union(retweetsFromMe).ToList();

                if (retweetsFromEmployer != null) newsfeed.Retweets = newsfeed.Retweets.Union(retweetsFromEmployer).ToList();

                if (retweetsFromPeersReceived != null) newsfeed.Retweets = newsfeed.Retweets.Union(retweetsFromPeersReceived).ToList();

                if (retweetsFromPeersRequested != null) newsfeed.Retweets = newsfeed.Retweets.Union(retweetsFromPeersRequested).ToList();

                newsfeed.Retweets = newsfeed.Retweets.OrderByDescending(x => x.PublishDateTime).ToList();

 
                return newsfeed;
            }

        }

        public static int LikePost(Guid AuthorKey, Guid postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisPost = db.Posts
                    .Include("PostLikes")
                    .Include("Author")
                    .Single(x => x.Key == postKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);
                PostLike newLike = new PostLike();
                Guid newGuid = Guid.NewGuid();
                newLike.Key = newGuid;
                newLike.Author = author;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Post = thisPost;
                db.PostLikes.Add(newLike);

                Suscription thisSuscription = null;
                Event thisEvent = null;
                Notification notification = null;

                //suscribe the author to receive notifications from this post, from now on
                if (AuthorKey != author.ReferenceKey)
                {
                     thisSuscription = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.PostILiked, Suscriber = author, ReferencePoint = newGuid };

                    db.Suscriptions.Add(thisSuscription);
               
                //register the event of liking the post
               
                     thisEvent = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.LikedMyPost, TriggeredBy = author, TriggeredOn = DateTime.Now };

                    db.Events.Add(thisEvent);
                
                //dont notify if its yourself
               
                    notification = new Notification { Key = Guid.NewGuid(), Event = thisEvent, NotifiedTo = thisPost.Author };

                    db.Notifications.Add(notification);
                }

                db.SaveChanges();
                return thisPost.PostLikes.Count;
            }

        }

        public static int UnLikePost(Guid AuthorUserAccountKey, Guid postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisPost = db.Posts.FirstOrDefault(x => x.Key == postKey);
                var author = db.UserAccounts.FirstOrDefault(x => x.Key == AuthorUserAccountKey);
                var unlike = db.PostLikes.FirstOrDefault(x => x.Post.Key == postKey && x.Author.ReferenceKey == AuthorUserAccountKey);
                db.PostLikes.Remove(unlike);

                db.SaveChanges();

                return thisPost.PostLikes.Count;
            }
        }

        public static int LikeComment(Guid AuthorKey, Guid commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisComment = db.Comments
                    .Include("CommentLikes")
                    .FirstOrDefault(x => x.Key == commentKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);
                CommentLike newLike = new CommentLike();
                newLike.Author = author;
                Guid newGuid = Guid.NewGuid();
                newLike.Key = newGuid;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Comment  = thisComment;
                db.CommentLikes.Add(newLike);


                //suscribe the author to receive notifications from this post, from now on
                //Suscription thisSuscription = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType., Suscriber = author, ReferencePoint = newGuid };

                //db.Suscriptions.Add(thisSuscription);
                //register the event of liking the post
                if (AuthorKey != thisComment.Author.ReferenceKey)
                {
                    Event thisEvent = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.LikedMyComment, TriggeredBy = author, TriggeredOn = DateTime.Now };

                    db.Events.Add(thisEvent);

                    Notification notification = new Notification { Key = Guid.NewGuid(), Event = thisEvent, NotifiedTo = thisComment.Author };

                    db.Notifications.Add(notification);
                }

                db.SaveChanges();

                return thisComment.CommentLikes.Count;
            }
        }

        public static int UnLikeComment(Guid AuthorKey, Guid commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisComment = db.Comments.FirstOrDefault(x => x.Key == commentKey);
                //var author = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey  == AuthorKey);
                var unlike = db.CommentLikes.FirstOrDefault(x => x.Comment.Key == commentKey && x.Author.ReferenceKey == AuthorKey);
                db.CommentLikes.Remove(unlike);
                db.SaveChanges();

                return thisComment.CommentLikes.Count;
            }
        }



        public static Guid SubmitNewTweet(Guid AuthorKey, Guid wallOwnerReferenceKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();
                var wall = db.ContentStreams
                    .Include("Owner")
                    .FirstOrDefault(x => x.Owner.ReferenceKey == wallOwnerReferenceKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);
                
                Tweet newTweet = new Tweet();
                newTweet.Author = author;
                newTweet.Key = newGuid;
                newTweet.PublishDateTime = DateTime.Now;
                newTweet.Text = text;
                newTweet.Wall = wall;

                db.Tweets.Add(newTweet);

                var hashtag = text.Substring(0,text.IndexOf(" "));
                var tag = db.Tags.FirstOrDefault(x=>x.Name==hashtag);
                var suscriptions = db.Suscriptions.Where(x=>x.ReferencePoint==tag.Key).ToList();

                //suscribe the author to receive notifications from this post, from now on
                //Suscription thisSuscription = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.TweetOnTagIBelong, Suscriber = author, ReferencePoint = newGuid };

                //db.Suscriptions.Add(thisSuscription);

                //register the event of liking the post
                if (AuthorKey != wallOwnerReferenceKey)
                {
                    Event thisEvent = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.LikedMyPost, TriggeredBy = author, TriggeredOn = DateTime.Now };

                    db.Events.Add(thisEvent);

                    Notification notification = new Notification { Key = Guid.NewGuid(), Event = thisEvent, NotifiedTo = wall.Owner };

                    db.Notifications.Add(notification);
                }

                db.SaveChanges();
                return newGuid;
            }
        }

     

        public static Guid  SubmitNewPost(Guid AuthorKey, Guid wallOwnerReferenceKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();
                var wall = db.ContentStreams
                    .Include("Owner")
                    .FirstOrDefault(x => x.Owner.ReferenceKey == wallOwnerReferenceKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);

                Post newPost = new Post();
                newPost.Author = author;
                newPost.Key = newGuid;
                newPost.PublishDateTime = DateTime.Now;
                newPost.Text = text;
                newPost.Wall = wall;

                db.Posts.Add(newPost);

                Suscription thisSuscription = null;
                Suscription thisSuscription2 = null;
                Event thisEvent = null;
                Notification notification = null;

                //suscribe the author to receive notifications from this post, from now on
                if (AuthorKey != wallOwnerReferenceKey)
                {
                    thisSuscription = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.MyPost  , Suscriber = author, ReferencePoint = newGuid };
                    thisSuscription2 = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.PostOnMyWall , Suscriber = wall.Owner, ReferencePoint = newGuid };

                    db.Suscriptions.Add(thisSuscription);
                    db.Suscriptions.Add(thisSuscription2);

                    //register the event of liking the post

                    thisEvent = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.NewPostOnMyWall , TriggeredBy = author, TriggeredOn = DateTime.Now };

                    db.Events.Add(thisEvent);

                    //dont notify if its yourself

                    notification = new Notification { Key = Guid.NewGuid(), Event = thisEvent, NotifiedTo = wall.Owner };

                    db.Notifications.Add(notification);
                }


                db.SaveChanges();
                return newGuid;
            }
        }

        public static Guid SubmitNewComment(Guid AuthorKey, Guid postKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid  newGuid = Guid.NewGuid();
                var post = db.Posts
                    .Include("Author")
                    .Include("Wall.Owner")
                    .FirstOrDefault(x => x.Key == postKey);
                // var author = db.UserAccounts.Single(x => x.Key == AuthorKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);

                Comment newComment = new Comment();
                newComment.Author = author;
                newComment.Key = newGuid;
                newComment.PublishDateTime = DateTime.Now;
                newComment.Text = text;
                newComment.Post = post;

                db.Comments.Add(newComment);

                Suscription thisSuscription = null;
                Suscription thisSuscription2 = null;
                Event thisEvent = null;
                Event thisEvent2 = null;
                Notification notification = null;

                //suscribe the author to receive notifications from this post, from now on
                if (AuthorKey != post.Wall.Owner.ReferenceKey)
                {
                    thisSuscription = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.MyComment , Suscriber = author, ReferencePoint = newGuid };
                    thisSuscription2 = new Suscription { Key = Guid.NewGuid(), Type = SuscriptionType.CommentOnPostOnMyWall, Suscriber = post.Wall.Owner, ReferencePoint = newGuid };

                    db.Suscriptions.Add(thisSuscription);
                    db.Suscriptions.Add(thisSuscription2);

                    //register the event of liking the post

                    thisEvent = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.NewCommentOnPostOnMyWall , TriggeredBy = author, TriggeredOn = DateTime.Now };
                    thisEvent2 = new Event { Key = Guid.NewGuid(), PostOrComment = newGuid, Type = EventType.NewCommentOnPostILiked,  TriggeredBy = author, TriggeredOn = DateTime.Now };

                    db.Events.Add(thisEvent);
                    db.Events.Add(thisEvent2);

                    //dont notify if its yourself

                    notification = new Notification { Key = Guid.NewGuid(), Event = thisEvent, NotifiedTo = post.Wall.Owner };
                    db.Notifications.Add(notification);

                    var suscriptions = db.Suscriptions.Where(x => x.ReferencePoint == post.Key && x.Type == SuscriptionType.PostILiked).ToList();

                    foreach (Suscription suscription in suscriptions)
                    {
                        db.Notifications.Add(new Notification { Key=Guid.NewGuid(), Event=thisEvent2 , NotifiedTo = suscription.Suscriber   });
                    }

                    
                }


                db.SaveChanges();
                return newGuid;
            }  
        }

        public static Guid SubmitNewRetweet(Guid AuthorKey, Guid tweetKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();

                var wall = db.ContentStreams.FirstOrDefault(x => x.Owner.ReferenceKey == AuthorKey);

                var tweet = db.Tweets.FirstOrDefault(x => x.Key == tweetKey);
                // var author = db.UserAccounts.Single(x => x.Key == AuthorKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);

                Retweet newRetweet = new Retweet();
                newRetweet.Author = author;
                newRetweet.Key = newGuid;
                newRetweet.PublishDateTime = DateTime.Now;
                newRetweet.Tweet = tweet;
                newRetweet.Wall = wall;

                db.Retweets.Add(newRetweet);
                db.SaveChanges();
                return newGuid;
            }
        }

        public static  void DeletePost(Guid  postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
              //  db.Configuration.LazyLoadingEnabled = false;
                var post = db.Posts
                    .Include("Author")
                    .Include("PostLikes.Author")
                    .Include("Comments.CommentLikes")
                    .Include("Wall")
                    .SingleOrDefault(x => x.Key == postKey);

                List<CommentLike> commentLikesToDelete = new List<CommentLike>();
                List<Comment> commentsToDelete = new List<Comment>();
                List<PostLike> postLikesToDelete = new List<PostLike>();

                foreach (Comment comment in post.Comments)
                {
                    foreach (CommentLike like in comment.CommentLikes)
                    {
                        commentLikesToDelete.Add(like);
                    }
                    commentsToDelete.Add(comment);
                }
                foreach (PostLike like in post.PostLikes)
                {
                    postLikesToDelete.Add(like);
                }

                foreach (var item in commentLikesToDelete)
                {
                    db.CommentLikes.Remove(item);
                }

                foreach (var item in commentsToDelete)
                {
                    db.Comments.Remove(item);
                }

                foreach (var item in postLikesToDelete)
                {
                    db.PostLikes.Remove(item);
                }

                db.Posts.Remove(post);

                db.SaveChanges();
            }
        }

        public static void DeleteTweet(Guid tweetKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                //  db.Configuration.LazyLoadingEnabled = false;
                var tweet = db.Tweets
                    .Include("Author")
                    .Include("Retweets")
                    .Include("Wall")
                    .SingleOrDefault(x => x.Key == tweetKey);

                List<Retweet> retweetsToDelete = new List<Retweet>();


               
                foreach (Retweet  rt in tweet.Retweets)
                {
                    retweetsToDelete.Add(rt);
                }

              

                foreach (var item in retweetsToDelete)
                {
                    db.Retweets.Remove(item);
                }

                db.Tweets.Remove(tweet);

                db.SaveChanges();
            }
        }

        public static void DeleteComment(Guid commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var comment = db.Comments
                    .Include("CommentLikes")
                    .SingleOrDefault(x => x.Key == commentKey);

                List<CommentLike> commentLikesToDelete = new List<CommentLike>();

                foreach (CommentLike like in comment.CommentLikes)
                {
                    commentLikesToDelete.Add(like);
                }

                foreach (var item in commentLikesToDelete)
                {
                    db.CommentLikes.Remove(item);
                }

                db.Comments.Remove(comment);
                db.SaveChanges();
            }
        }

        public static  void DeleteRetweet(Guid  retweetKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var retweet = db.Retweets 
                    .SingleOrDefault(x => x.Key == retweetKey );
                retweet.Tweet = null;
                db.Retweets.Remove(retweet);
                db.SaveChanges();
            }
        }

        public static Post  GetPost(Guid key)
        {
            Post thisPost = new Post();

            using (var db = new FHNWPrototypeDB())
            {
                var result = db.Posts
                    .Include("Author")
                    .Include("PostLikes.Author")
                    .Include("Comments.CommentLikes")
                    .Include("Wall")
                    .FirstOrDefault(x => x.Key == key);

                thisPost.Key = result.Key;
                thisPost.PostLikes = result.PostLikes;
                thisPost.PublishDateTime = result.PublishDateTime;
                thisPost.Text = result.Text;
                thisPost.Author = result.Author;
            }

            return thisPost;
        }

        public static Tweet GetTweet(Guid key)
        {
            Tweet  thisTweet = new Tweet();

            using (var db = new FHNWPrototypeDB())
            {
                var result = db.Tweets 
                    .Include("Author")
                    .Include("Retweets.Author")
                    .Include("Wall")
                    .FirstOrDefault(x => x.Key == key);

                thisTweet.Key = result.Key;
                thisTweet.Retweets = result.Retweets;
                thisTweet.PublishDateTime = result.PublishDateTime;
                thisTweet.Text = result.Text;
                thisTweet.Author = result.Author;
            }

            return thisTweet;
        }

        public static Comment  GetComment(Guid key)
        {
            Comment thisComment = new Comment();

            using (var db = new FHNWPrototypeDB())
            {

                var result = db.Comments 
                   .Include("Author")
                   .Include("CommentLikes.Author")
                   .Include("CommentLikes")
                   .Include("Post")
                   .FirstOrDefault(x => x.Key == key);

                thisComment.Key = result.Key;
                thisComment.Text = result.Text;
                thisComment.Post = result.Post;
                thisComment.PublishDateTime = result.PublishDateTime;
                thisComment.Author = result.Author;
                thisComment.CommentLikes = result.CommentLikes;

            }

            return thisComment;
        }


        public static Retweet GetRetweet(Guid key)
        {
            Retweet thisRetweet = new Retweet();

            using (var db = new FHNWPrototypeDB())
            {

                var result = db.Retweets 
                   .Include("Author")
                   .Include("Tweet")
                   .FirstOrDefault(x => x.Key == key);

                thisRetweet.Key = result.Key;
                thisRetweet.Tweet = result.Tweet;
                thisRetweet.PublishDateTime = result.PublishDateTime;
                thisRetweet.Author = result.Author;

            }

            return thisRetweet;
        }


    }
}
