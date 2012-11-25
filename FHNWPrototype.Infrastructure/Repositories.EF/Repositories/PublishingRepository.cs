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

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class PublishingRepository
    {
        //private FHNWPrototypeDB db = null;

        //public ContentStreamRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}

        public static ContentStream GetWallByOwnerReferenceKey(Guid OwnerKey)
        {
           // var result = null;
            using (var db = new FHNWPrototypeDB())
            {
                ContentStream result = db.ContentStreams
                              .Include("Posts.Author")
                              .Include("Posts.PostLikes.Author")
                              .Include("Posts.Comments.Author")
                              .Include("Posts.Comments.CommentLikes.Author")
                              .FirstOrDefault(x => x.Owner.ReferenceKey == OwnerKey);
                if (result != null)
                {
                    var newPostList = result.Posts.OrderByDescending(x => x.PublishDateTime).ToList();
                    foreach (var post in newPostList)
                    {
                        var newCommentList = post.Comments.OrderBy(x => x.PublishDateTime).ToList();
                        post.Comments = newCommentList;
                    }
                    result.Posts = newPostList;
                }
                else
                {
                    result = new ContentStream();
                    result.Posts = new List<Post>();

                }

                

                return result;
            }
          
        }

        public static ContentStream GetNewsfeed(Guid OwnerKey)
        {
            ContentStream newsfeed  = new ContentStream();
            newsfeed.Posts = new List<Post>();
            newsfeed.Tweets = new List<Domain.Publishing.Tweets.Tweet>();


            List<Post> postFromPeersReceived = new List<Post>();
            List<Post> postFromPeersRequested = new List<Post>();

            List<Post> allPostsFromNewsfeed = new List<Post>();

            using (var db = new FHNWPrototypeDB())
            {
                db.Configuration.LazyLoadingEnabled = false;

                newsfeed.Owner = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == OwnerKey);

                if (newsfeed.Owner.ReferenceType == Domain._Base.Accounts.AccountType.UserAccount)
                {
                    var owner = db.UserAccounts
                                            .Include("FriendshipsReceived.Sender")
                                            .Include("FriendshipsRequested.Receiver")
                                            .FirstOrDefault(x => x.Key == OwnerKey);

                    foreach (FriendshipStateInfo friendship in owner.FriendshipsReceived)
                    {
                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x=>x.ReferenceKey==friendship.Sender.Key);


                        var temp=  db.ContentStreams
                                                            .Include("Owner")
                                                           .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                             .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Sender.Key)
                                                            .Posts.Where(x => x.Author.ReferenceKey == friendship.Sender.Key)
                                                             .OrderByDescending(y => y.PublishDateTime)
                                                             .Take(3).ToList();

                        if (temp != null) postFromPeersReceived.AddRange(temp);

                        //postFromPeersReceived = db.ContentStreams
                        //                                        .Include("Owner")
                        //                                        .Include("Posts.Author")
                        //                                        .SingleOrDefault(x=>x.Owner.ReferenceKey==peerProfile.ReferenceKey)
                        //                                        .Posts.Where(x => x.Author.ReferenceKey == peerProfile.ReferenceKey)
                        //                                        .OrderByDescending(y => y.PublishDateTime)
                        //                                        .Take(3).ToList();
                    }

                    foreach (FriendshipStateInfo friendship in owner.FriendshipsRequested)
                    {
                      //  var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == friendship.Receiver.Key);

                        var temp = db.ContentStreams
                                                                    .Include("Owner")
                                                                      .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == friendship.Receiver.Key)
                                                                     .Posts.Where(x => x.Author.ReferenceKey == friendship.Receiver.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .Take(3).ToList();

                        if (temp != null) postFromPeersRequested.AddRange(temp);
                    }

                }

                if (newsfeed.Owner.ReferenceType == Domain._Base.Accounts.AccountType.OrganizationAccount)
                {
                    var owner = db.OrganizationAccounts
                                                    .Include("PartnershipsReceived.Sender")
                                                    .Include("PartnershipsRequested.Receiver")
                                                    .FirstOrDefault(x => x.Key == OwnerKey);

                    foreach (PartnershipStateInfo partnership in owner.PartnershipsReceived)
                    {

                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == partnership.Sender.Key);

                        var temp = db.ContentStreams
                                                                    .Include("Owner")
                                                                    .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Sender.Key)
                                                                    .Posts.Where(x => x.Author.ReferenceKey == partnership.Sender.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .Take(3).ToList();

                        if (temp != null) postFromPeersReceived.AddRange(temp);
                    }

                    foreach (PartnershipStateInfo partnership in owner.PartnershipsRequested)
                    {
                       // var peerProfile = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == partnership.Receiver.Key);

                        var temp = db.ContentStreams
                                                                    .Include("Owner")
                                                                   .Include("Posts.Author")
                                                          .Include("Posts.PostLikes.Author")
                                                          .Include("Posts.Comments.Author")
                                                          .Include("Posts.Comments.CommentLikes.Author")
                                                                    .FirstOrDefault(x => x.Owner.ReferenceKey == partnership.Receiver.Key)
                                                                    .Posts.Where(x => x.Author.ReferenceKey == partnership.Receiver.Key)
                                                                    .OrderByDescending(y => y.PublishDateTime)
                                                                    .Take(3).ToList();

                        if (temp != null) postFromPeersRequested.AddRange(temp);
                    }

                }

                if (postFromPeersReceived != null) newsfeed.Posts= newsfeed.Posts.Union(postFromPeersReceived).ToList();

                if (postFromPeersRequested != null) newsfeed.Posts = newsfeed.Posts.Union(postFromPeersRequested).ToList();

                newsfeed.Posts = newsfeed.Posts.OrderByDescending(x => x.PublishDateTime).ToList();
 
                return newsfeed;
            }

        }

        public static int LikePost(Guid AuthorKey, Guid postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisPost = db.Posts
                    .Include("PostLikes")
                    .Single(x => x.Key == postKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);
                PostLike newLike = new PostLike();
                newLike.Author = author;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Post = thisPost;
                db.PostLikes.Add(newLike);
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
                var thisComment = db.Comments.FirstOrDefault(x => x.Key == commentKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);
                CommentLike newLike = new CommentLike();
                newLike.Author = author;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Comment  = thisComment;
                db.CommentLikes.Add(newLike);
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

        public static Guid  SubmitNewPost(Guid AuthorKey, Guid wallOwnerReferenceKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();
                var wall = db.ContentStreams.FirstOrDefault(x => x.Owner.ReferenceKey == wallOwnerReferenceKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);

                Post newPost = new Post();
                newPost.Author = author;
                newPost.Key = newGuid;
                newPost.PublishDateTime = DateTime.Now;
                newPost.Text = text;
                newPost.Wall = wall;

                db.Posts.Add(newPost);
                db.SaveChanges();
                return newGuid;
            }
        }

        public static Guid SubmitNewComment(Guid AuthorKey, Guid postKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid  newGuid = Guid.NewGuid();
                var post = db.Posts.FirstOrDefault(x => x.Key == postKey);
                // var author = db.UserAccounts.Single(x => x.Key == AuthorKey);
                var author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == AuthorKey);

                Comment newComment = new Comment();
                newComment.Author = author;
                newComment.Key = newGuid;
                newComment.PublishDateTime = DateTime.Now;
                newComment.Text = text;
                newComment.Post = post;

                db.Comments.Add(newComment);
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

        public static  void DeleteComment(Guid  commentKey)
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


    }
}
