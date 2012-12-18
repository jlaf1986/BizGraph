using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;
using FHNWPrototype.Domain.Publishing.Tweets;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class PublishingService
    {

       

      //  ContentStreamRepository contentStreamRepository = new ContentStreamRepository();

        public static ContentStreamViewModel GetContentStreamAsProfileWall(string ownerKey, string viewerKey)
        {
            ContentStream retrievedWall = PublishingRepository.GetContentStreamAsProfileWall(new Guid(ownerKey));

            ContentStreamViewModel result = new ContentStreamViewModel();
            result.Posts = new List<PostViewModel>();

            result.Tweets = new List<TweetViewModel>();

            result.Retweets = new List<RetweetViewModel>();

            foreach (Post post in retrievedWall.Posts)
            {
                PostViewModel thisPost = new PostViewModel();
                thisPost.Key = post.Key.ToString();
                thisPost.Text = post.Text;
                 
                //thisPost.AuthorKey = post.Author.ReferenceKey.ToString();
                //thisPost.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                 var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };
                       
                thisPost.PublishDateTime = post.PublishDateTime;
                thisPost.Comments = new List<CommentViewModel>();
                if (post.PostLikes != null)
                {
                    thisPost.Likes = post.PostLikes.Count();

                    var myLikeValueOnThisPost = post.PostLikes.FirstOrDefault(x => x.Author.ReferenceKey.ToString() == viewerKey);
                    if (myLikeValueOnThisPost != null)
                    {
                        thisPost.ILikedIt = true;
                    }
                    else
                    {
                        thisPost.ILikedIt = false;
                    }
                }
                else
                {
                    thisPost.Likes = 0;
                }
                thisPost.Likes = post.PostLikes.Count();
                foreach (Comment comment in post.Comments)
                {
                    CommentViewModel thisComment = new CommentViewModel();
                    thisComment.Key = comment.Key.ToString();
                    thisComment.Text = comment.Text;
                    //thisComment.AuthorKey = comment.Author.ReferenceKey.ToString();
                    //thisComment.AuthorName = SecurityRepository.GetCompleteProfile(comment.Author.ReferenceKey);

                     var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
                    thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
                         

                    thisComment.PublishDateTime = comment.PublishDateTime;

                    if (comment.CommentLikes != null)
                    {
                        thisComment.Likes = comment.CommentLikes.Count;
                        var myLikeValueOnThisComment = comment.CommentLikes.FirstOrDefault(x => x.Author.ReferenceKey.ToString() == viewerKey);
                        if (myLikeValueOnThisComment != null)
                        {
                            thisComment.ILikedIt = true;
                        }
                        else
                        {
                            thisComment.ILikedIt = false;
                        }
                    }

                   // thisComment.Likes = comment.CommentLikes.Count();
                    thisPost.Comments.Add(thisComment);
                }
                result.Posts.Add(thisPost);
            }

            foreach (Tweet tweet in retrievedWall.Tweets)
            {
                TweetViewModel thisTweet = new TweetViewModel();

                thisTweet.Key = tweet.Key.ToString();

                thisTweet.Text = tweet.Text;

                thisTweet.PublishDateTime = tweet.PublishDateTime;

                var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(tweet.Author);

                thisTweet.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = tweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };

                thisTweet.Retweets = 0;

                

                result.Tweets.Add(thisTweet);
            }

            foreach (Retweet retweet in retrievedWall.Retweets)
            {
                RetweetViewModel thisRetweet = new RetweetViewModel();

                var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(retweet.Tweet.Author);

                var retweetAuthorProfile = SecurityRepository.GetCompleteProfile(retweet.Author);

                thisRetweet.TweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = retweet.Tweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };

                thisRetweet.RetweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = retweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = retweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = retweetAuthorProfile.Description1, Description2 = retweetAuthorProfile.Description2 };

                thisRetweet.Text = retweet.Tweet.Text;

                thisRetweet.RetweetKey = retweet.Key.ToString();
                thisRetweet.TweetKey = retweet.Tweet.Key.ToString();

                thisRetweet.TweetPublishDateTime = retweet.Tweet.PublishDateTime;

               

                result.Retweets.Add(thisRetweet);
            }

            return result;
        }

        public static ContentStreamViewModel GetContentStreamAsNewsfeed(string ownerKey, string viewerKey)
        {
            ContentStream retrievedWall = PublishingRepository.GetContentStreamAsNewsfeed(new Guid(ownerKey));

            ContentStreamViewModel result = new ContentStreamViewModel();
            result.Posts = new List<PostViewModel>();
            result.Tweets = new List<TweetViewModel>();
            result.Retweets = new List<RetweetViewModel>();

            foreach (Post post in retrievedWall.Posts)
            {
                PostViewModel thisPost = new PostViewModel();
                thisPost.Key = post.Key.ToString();
                thisPost.Text = post.Text;

                //thisPost.AuthorKey = post.Author.ReferenceKey.ToString();
                //thisPost.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };

                thisPost.PublishDateTime = post.PublishDateTime;
                thisPost.Comments = new List<CommentViewModel>();
                if (post.PostLikes != null)
                {
                    thisPost.Likes = post.PostLikes.Count();

                    var myLikeValueOnThisPost = post.PostLikes.FirstOrDefault(x => x.Author.ReferenceKey.ToString() == viewerKey);
                    if (myLikeValueOnThisPost != null)
                    {
                        thisPost.ILikedIt = true;
                    }
                    else
                    {
                        thisPost.ILikedIt = false;
                    }
                }
                else
                {
                    thisPost.Likes = 0;
                }
                thisPost.Likes = post.PostLikes.Count();
                foreach (Comment comment in post.Comments)
                {
                    CommentViewModel thisComment = new CommentViewModel();
                    thisComment.Key = comment.Key.ToString();
                    thisComment.Text = comment.Text;
                    //thisComment.AuthorKey = comment.Author.ReferenceKey.ToString();
                    //thisComment.AuthorName = SecurityRepository.GetCompleteProfile(comment.Author.ReferenceKey);

                    var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
                    thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };


                    thisComment.PublishDateTime = comment.PublishDateTime;

                    if (comment.CommentLikes != null)
                    {
                        thisComment.Likes = comment.CommentLikes.Count;
                        var myLikeValueOnThisComment = comment.CommentLikes.FirstOrDefault(x => x.Author.ReferenceKey.ToString() == viewerKey);
                        if (myLikeValueOnThisComment != null)
                        {
                            thisComment.ILikedIt = true;
                        }
                        else
                        {
                            thisComment.ILikedIt = false;
                        }
                    }

                    // thisComment.Likes = comment.CommentLikes.Count();
                    thisPost.Comments.Add(thisComment);
                }
                result.Posts.Add(thisPost);
            }

            foreach (Tweet tweet in retrievedWall.Tweets)
            {
                TweetViewModel thisTweet = new TweetViewModel();

                thisTweet.Key = tweet.Key.ToString();

                thisTweet.Text = tweet.Text;

                thisTweet.PublishDateTime = tweet.PublishDateTime;

                var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(tweet.Author);

                thisTweet.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = tweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };

                thisTweet.Retweets = 0;



                result.Tweets.Add(thisTweet);
            }

            foreach (Retweet retweet in retrievedWall.Retweets)
            {
                RetweetViewModel thisRetweet = new RetweetViewModel();

                var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(retweet.Tweet.Author);

                var retweetAuthorProfile = SecurityRepository.GetCompleteProfile(retweet.Author);

                thisRetweet.TweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = retweet.Tweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };

                thisRetweet.RetweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = retweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = retweet.Author.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = retweetAuthorProfile.Description1, Description2 = retweetAuthorProfile.Description2 };

                thisRetweet.Text = retweet.Tweet.Text;

                thisRetweet.RetweetKey = retweet.Key.ToString();
                thisRetweet.TweetKey = retweet.Tweet.Key.ToString();

                thisRetweet.TweetPublishDateTime = retweet.Tweet.PublishDateTime;



                result.Retweets.Add(thisRetweet);
            }

            return result;
        }

        public static int LikePost(string AuthorUserAccountKey, string postKey)
        {

          var counter=  PublishingRepository.LikePost(new Guid(AuthorUserAccountKey), new Guid(postKey));

          return counter;
        }

        public static int UnLikePost(string AuthorUserAccountKey, string postKey)
        {
           var counter= PublishingRepository.UnLikePost(new Guid(AuthorUserAccountKey), new Guid(postKey));

           return counter;
        }

        public static int LikeComment(string AuthorUserAccountKey, string commentKey)
        {
          var counter=  PublishingRepository.LikeComment(new Guid(AuthorUserAccountKey), new Guid(commentKey));

            return counter;
        }

        public static int UnLikeComment(string AuthorUserAccountKey, string commentKey)
        {

            var counter= PublishingRepository.UnLikeComment(new Guid(AuthorUserAccountKey), new Guid(commentKey));

            return counter;
        }

        public static string SubmitNewPost(string AuthorUserAccountKey, string wallOwnerUserAccountKey, string text)
        {
            Guid  returnGuid = PublishingRepository.SubmitNewPost(new Guid(AuthorUserAccountKey), new Guid(wallOwnerUserAccountKey), text);
            return returnGuid.ToString();
      
        }

        public static string SubmitNewTweet(string AuthorUserAccountKey, string wallOwnerUserAccountKey, string text)
        {
            Guid returnGuid = PublishingRepository.SubmitNewTweet(new Guid(AuthorUserAccountKey), new Guid(wallOwnerUserAccountKey), text);
            return returnGuid.ToString();

        }

        public static string SubmitNewComment(string AuthorUserAccountKey, string postKey, string text)
        {
            Guid  returnedGuid =PublishingRepository.SubmitNewComment(new Guid(AuthorUserAccountKey), new Guid(postKey), text);
            return returnedGuid.ToString();
           
        }

        public static string SubmitNewRetweet(string AuthorUserAccountKey, string tweetKey)
        {
            Guid returnedGuid = PublishingRepository.SubmitNewRetweet(new Guid(AuthorUserAccountKey), new Guid(tweetKey));
            return returnedGuid.ToString();

        }


        public static void DeletePost(string postKey)
        {
            PublishingRepository.DeletePost(new Guid(postKey));
        }

        public static void DeleteTweet(string tweetKey)
        {
            PublishingRepository.DeleteTweet(new Guid(tweetKey));
        }

        public static void DeleteComment(string commentKey)
        {
            PublishingRepository.DeleteComment(new Guid(commentKey));
        }

        public static void DeleteRetweet(string retweetKey)
        {
            PublishingRepository.DeleteRetweet(new Guid(retweetKey));
        }

        public static PostViewModel GetPost(string postKey)
        {
            Post retrievedPost = PublishingRepository.GetPost(new Guid(postKey));
            PostViewModel newPost = new PostViewModel();
            newPost.Key = retrievedPost.Key.ToString();
            newPost.ILikedIt = false;
            newPost.Likes = retrievedPost.PostLikes.Count;
            newPost.Text = retrievedPost.Text;
            newPost.PublishDateTime = retrievedPost.PublishDateTime;

            var postAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedPost.Author);

            newPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType=postAuthorProfile.BasicProfile.ReferenceType }, FullName=postAuthorProfile.FullName, Description1=postAuthorProfile.Description1, Description2=postAuthorProfile.Description2  };
            return newPost;
        }

        public static TweetViewModel GetTweet(string tweetKey)
        {
            Tweet retrievedTweet = PublishingRepository.GetTweet(new Guid(tweetKey));
            TweetViewModel newTweet = new TweetViewModel();
            newTweet.Key = retrievedTweet.Key.ToString();
            newTweet.Retweets = retrievedTweet.Retweets.Count;
            newTweet.Text = retrievedTweet.Text;
            newTweet.PublishDateTime = retrievedTweet.PublishDateTime;

            var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedTweet.Author);

            newTweet.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = tweetAuthorProfile.BasicProfile.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };
            return newTweet;
        }

        public static CommentViewModel GetComment(string commentKey)
        {
            Comment retrievedComment = PublishingRepository.GetComment(new Guid(commentKey));
            CommentViewModel newComment = new CommentViewModel();

            newComment.Key = retrievedComment.Key.ToString();
            newComment.ILikedIt = false;
            newComment.Likes = retrievedComment.CommentLikes.Count;
            newComment.Text = retrievedComment.Text;
            newComment.PublishDateTime = retrievedComment.PublishDateTime;

            var commentAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedComment.Author);
            newComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
            
            return newComment;
        }

        public static RetweetViewModel GetRetweet(string retweetKey)
        {
            Retweet retrievedRetweet = PublishingRepository.GetRetweet(new Guid(retweetKey));
            RetweetViewModel newRetweet = new RetweetViewModel();

            newRetweet.RetweetKey  = retrievedRetweet.Key.ToString();

            newRetweet.TweetKey = retrievedRetweet.Tweet.Key.ToString();

            var tweetAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedRetweet.Tweet.Author);

            newRetweet.TweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = tweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = tweetAuthorProfile.BasicProfile.ReferenceType }, FullName = tweetAuthorProfile.FullName, Description1 = tweetAuthorProfile.Description1, Description2 = tweetAuthorProfile.Description2 };

            newRetweet.Text = retrievedRetweet.Tweet.Text;
            newRetweet.PublishDateTime  = retrievedRetweet.PublishDateTime;

            var retweetAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedRetweet.Author);
            newRetweet.RetweetAuthor = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = retweetAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = retweetAuthorProfile.BasicProfile.ReferenceType }, FullName = retweetAuthorProfile.FullName, Description1 = retweetAuthorProfile.Description1, Description2 = retweetAuthorProfile.Description2 };
            newRetweet.TweetPublishDateTime = retrievedRetweet.Tweet.PublishDateTime;
            return newRetweet;
        }


    }
}
