using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;
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

        public static ContentStreamViewModel GetContentStreamByOwnerReferenceKey(string ownerKey, string viewerKey)
        {
            ContentStream retrievedWall = PublishingRepository.GetWallByOwnerReferenceKey(new Guid(ownerKey));

            ContentStreamViewModel result = new ContentStreamViewModel();
            result.Posts = new List<PostViewModel>();
            foreach (Post post in retrievedWall.Posts)
            {
                PostViewModel thisPost = new PostViewModel();
                thisPost.Key = post.Key.ToString();
                thisPost.Text = post.Text;
                 
                //thisPost.AuthorKey = post.Author.ReferenceKey.ToString();
                //thisPost.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                 var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };
                       
                thisPost.TimeStamp = post.PublishDateTime;
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
                         

                    thisComment.TimeStamp = comment.PublishDateTime;

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

            return result;
        }

        public static ContentStreamViewModel GetContentStreamAsNewsfeed(string ownerKey, string viewerKey)
        {
            ContentStream retrievedWall = PublishingRepository.GetNewsfeed(new Guid(ownerKey));

            ContentStreamViewModel result = new ContentStreamViewModel();
            result.Posts = new List<PostViewModel>();
            foreach (Post post in retrievedWall.Posts)
            {
                PostViewModel thisPost = new PostViewModel();
                thisPost.Key = post.Key.ToString();
                thisPost.Text = post.Text;

                //thisPost.AuthorKey = post.Author.ReferenceKey.ToString();
                //thisPost.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };

                thisPost.TimeStamp = post.PublishDateTime;
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


                    thisComment.TimeStamp = comment.PublishDateTime;

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

        public static string SubmitNewComment(string AuthorUserAccountKey, string postKey, string text)
        {
            Guid  returnedGuid =PublishingRepository.SubmitNewComment(new Guid(AuthorUserAccountKey), new Guid(postKey), text);
            return returnedGuid.ToString();
           
        }

        public static void DeletePost(string postKey)
        {
            PublishingRepository.DeletePost(new Guid(postKey));
        }

        public static void DeleteComment(string commentKey)
        {
            PublishingRepository.DeleteComment(new Guid(commentKey));
        }

        public static PostViewModel GetPost(string postKey)
        {
            Post retrievedPost = PublishingRepository.GetPost(new Guid(postKey));
            PostViewModel newPost = new PostViewModel();
            newPost.Key = retrievedPost.Key.ToString();
            newPost.ILikedIt = false;
            newPost.Likes = retrievedPost.PostLikes.Count;
            newPost.Text = retrievedPost.Text;
            newPost.TimeStamp = retrievedPost.PublishDateTime;

            var postAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedPost.Author);

            newPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType=postAuthorProfile.BasicProfile.ReferenceType }, FullName=postAuthorProfile.FullName, Description1=postAuthorProfile.Description1, Description2=postAuthorProfile.Description2  };
            return newPost;
        }

        public static CommentViewModel GetComment(string commentKey)
        {
            Comment retrievedComment = PublishingRepository.GetComment(new Guid(commentKey));
            CommentViewModel newComment = new CommentViewModel();

            newComment.Key = retrievedComment.Key.ToString();
            newComment.ILikedIt = false;
            newComment.Likes = retrievedComment.CommentLikes.Count;
            newComment.Text = retrievedComment.Text;
            newComment.TimeStamp = retrievedComment.PublishDateTime;

            var commentAuthorProfile = SecurityRepository.GetCompleteProfile(retrievedComment.Author);
            newComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
            
            return newComment;
        }


    }
}
