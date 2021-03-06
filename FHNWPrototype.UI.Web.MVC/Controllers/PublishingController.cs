﻿using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.UI.Web.MVC;
using FHNWPrototype.UI.Web.MVC.Controllers;
using FHNWPrototype.UI.Web.MVC.Signals;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FHNWPrototype.Application.Controllers
{
    [Authorize]
    public class PublishingController : Controller
    {
        [HttpPost]
        public JsonResult LikePost(string postKey)
        {
            CompleteProfile myProfile = (CompleteProfile) Session["myProfile"];
 
            var counter =  PublishingService.LikePost(myProfile.BasicProfile.ReferenceKey.ToString(), postKey);

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

            context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), postKey);

            var msg = new { success = true, postKey=postKey, counter = counter };

            context.Clients.Group(postKey).LikedPost(msg);

            context.Clients.Group(postKey).NotificationReceived(msg);
           
            return Json(msg);

        }
        [HttpPost]
        public JsonResult UnLikePost(string postKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


          var counter=  PublishingService.UnLikePost(myProfile.BasicProfile.ReferenceKey.ToString(), postKey);

          var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

          context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), postKey);

          var msg = new { success = true, postKey = postKey, counter = counter };

          context.Clients.Group(postKey).UnLikedPost(msg);

          return Json(msg);
        }
        [HttpPost]
        public JsonResult LikeComment(string commentKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
           var counter= PublishingService.LikeComment(myProfile.BasicProfile.ReferenceKey.ToString(), commentKey);

           var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

           context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), commentKey);

           var msg = new { success = true, commentKey = commentKey, counter = counter };

           context.Clients.Group(commentKey).LikedComment(msg);

           context.Clients.Group(commentKey).NotificationReceived(msg);

           return Json(msg);
        }
        [HttpPost]
        public JsonResult UnLikeComment(string commentKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
           var counter= PublishingService.UnLikeComment(myProfile.BasicProfile.ReferenceKey.ToString(), commentKey);

           var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

           context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), commentKey);

           var msg = new { success = true, commentKey = commentKey, counter = counter };

           context.Clients.Group(commentKey).UnLikedComment(msg);

           return Json(msg);
        }

        [HttpPost]
        public JsonResult SubmitNewPost(string wallOwnerUserAccountKey, string text)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            String returnedGuid = null;
            String processedHtml = null;
            var msg = new { success = true };

   
            PostView newPost = new PostView();
            returnedGuid = PublishingService.SubmitNewPost(myProfile.BasicProfile.ReferenceKey.ToString(), wallOwnerUserAccountKey, text);
            newPost.Key = returnedGuid;
            newPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
            newPost.Comments = new List<CommentView>();
            newPost.Likes = 0;
            newPost.Text = text;
            newPost.PublishDateTime = DateTime.Now;
                 
            processedHtml = PartialViewUtility.RenderPartialToString("_partial_section_post", newPost, ControllerContext);

      

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();
            string[] excluded = null;
            var result = new { postKey = returnedGuid, processedHtml = processedHtml, author = myProfile.FullName };
            context.Clients.Group(wallOwnerUserAccountKey, excluded).NewPostReceived(result);



            context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), returnedGuid);

            context.Clients.Group(returnedGuid).NotificationReceived(msg);

            return Json(msg);
           
        }

        [HttpPost]
        public JsonResult SubmitNewTweet(string wallOwnerUserAccountKey, string text)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            String returnedGuid = null;
            String processedHtml = null;
            var msg = new { success = true };

          
            TweetView newTweet = new TweetView();
            returnedGuid = PublishingService.SubmitNewTweet(myProfile.BasicProfile.ReferenceKey.ToString(), wallOwnerUserAccountKey, text);
            newTweet.Key = returnedGuid;
            newTweet.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
            newTweet.Text = text;
            newTweet.PublishDateTime = DateTime.Now;

            processedHtml = PartialViewUtility.RenderPartialToString("_partial_section_tweet", newTweet, ControllerContext);
 

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();
            string[] excluded = null;
            var result = new { tweetKey = returnedGuid, processedHtml = processedHtml, author = myProfile.FullName };
            context.Clients.Group(wallOwnerUserAccountKey, excluded).NewTweetReceived(result);



            context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), returnedGuid);

            context.Clients.Group(returnedGuid).NotificationReceived(msg);

            return Json(msg);

        }


        //Previously like this
        //[HttpPost]
        //public PartialViewResult SubmitNewPost(string wallOwnerUserAccountKey, string text)
        //{
        //    CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


        //    PostView newPost = new PostView();
        //    newPost.Key = PublishingService.SubmitNewPost(myProfile.BasicProfile.ReferenceKey.ToString(), wallOwnerUserAccountKey, text);

        //    newPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
        //    newPost.Comments = new List<CommentView>();
        //    newPost.Likes = 0;
        //    newPost.Text = text;
        //    newPost.TimeStamp = DateTime.Now.ToString();



        //    return PartialView("_partial_section_post", newPost);
        //}

        public PartialViewResult CreateMyInputForThisPost(string postKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

           
            CompleteProfileView viewerProfile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=myProfile.BasicProfile.ReferenceKey.ToString(),  AccountType=myProfile.BasicProfile.ReferenceType  }, FullName=myProfile.FullName };

            MyNewCommentView myNewComment = new MyNewCommentView { PostKey = postKey, Viewer = viewerProfile };
            return PartialView("_partial_my_new_comment", myNewComment);
        }

        [HttpPost]
        public JsonResult SubmitNewComment(string postKey,string wallOwnerAccountKey, string text)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            CommentView newComment = new CommentView();
            newComment.Key = PublishingService.SubmitNewComment(myProfile.BasicProfile.ReferenceKey.ToString(), postKey, text);
            newComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };

            newComment.Likes = 0;
            newComment.Text = text;
            newComment.PublishDateTime = DateTime.Now;


          

            string processedHtml = PartialViewUtility.RenderPartialToString("_partial_article_comment", newComment, ControllerContext);

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

            var msg = new { success = true };

            var result = new { postKey=postKey, processedHtml=processedHtml, author=myProfile.FullName };
            string[] excluded = null;
            context.Clients.Group(wallOwnerAccountKey,excluded).NewCommentReceived(result);

            context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), postKey);

            context.Clients.Group(postKey).NotificationReceived(msg);

            return Json(msg);

 
        }


        [HttpPost]
        public JsonResult SubmitNewRetweet(string tweetKey, string wallOwnerAccountKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            TweetViewModel retrievedTweet = PublishingService.GetTweet(tweetKey);

            RetweetView newRetweet = new RetweetView();
            newRetweet.RetweetKey = PublishingService.SubmitNewRetweet(myProfile.BasicProfile.ReferenceKey.ToString(), tweetKey);
            newRetweet.RetweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
            newRetweet.TweetKey = retrievedTweet.Key;

            newRetweet.TweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=retrievedTweet.Author.BasicProfile.ReferenceKey , AccountType=retrievedTweet.Author.BasicProfile.AccountType  }, FullName=retrievedTweet.Author.FullName , Description1=retrievedTweet.Author.Description1, Description2=retrievedTweet.Author.Description2  };
            newRetweet.PublishDateTime = DateTime.Now;
            newRetweet.Text = retrievedTweet.Text;
            newRetweet.TweetPublishDateTime = retrievedTweet.PublishDateTime.ToString();



            string processedHtml = PartialViewUtility.RenderPartialToString("_partial_section_retweet", newRetweet, ControllerContext);

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();

            var msg = new { success = true };

            var result = new { retweetKey = tweetKey, processedHtml = processedHtml, author = myProfile.FullName };
            string[] excluded = null;
            context.Clients.Group(wallOwnerAccountKey, excluded).NewRetweetReceived(result);

            context.Groups.Add(SignalRState.GetConnectionByUserId(User.Identity.Name), tweetKey);

            context.Clients.Group(tweetKey).NotificationReceived(msg);

            return Json(msg);


        }

        //[HttpPost]
        //public PartialViewResult SubmitNewComment(string postKey, string text)
        //{
        //    CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            

        //    CommentView newComment = new CommentView();
        //    newComment.Key = PublishingService.SubmitNewComment(myProfile.BasicProfile.ReferenceKey.ToString(), postKey, text);
        //    newComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
          
        //    newComment.Likes = 0;
        //    newComment.Text = text;
        //    newComment.TimeStamp = DateTime.Now.ToString();
        //    return PartialView("_partial_article_comment", newComment);
        //}

        [HttpPost]
        public PartialViewResult GetExternalPost(string postKey)
        {
            PostView newPost = new PostView();
            PostViewModel retrievedPost = PublishingService.GetPost(postKey);
            newPost.Key = retrievedPost.Key;
            
            newPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey =retrievedPost.Author.BasicProfile.ReferenceKey , AccountType = retrievedPost.Author.BasicProfile.AccountType }, FullName = retrievedPost.Author.FullName, Description1 = retrievedPost.Author.Description1 , Description2 = retrievedPost.Author.Description2  };
            newPost.Comments = new List<CommentView>();
            newPost.Likes = retrievedPost.Likes;
            newPost.Text = retrievedPost.Text;
            newPost.PublishDateTime = retrievedPost.PublishDateTime;
            return PartialView("_partial_section_post", newPost);
        }

        [HttpPost]
        public PartialViewResult GetExternalComment(string commentKey)
        {
            CommentView newComment = new CommentView();
            CommentViewModel retrievedComment = PublishingService.GetComment(commentKey);
            newComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = retrievedComment.Author.BasicProfile.ReferenceKey, AccountType = retrievedComment.Author.BasicProfile.AccountType }, FullName = retrievedComment.Author.FullName, Description1 = retrievedComment.Author.Description1, Description2 = retrievedComment.Author.Description2  };

            newComment.Likes = retrievedComment.Likes;
            newComment.Text = retrievedComment.Text;
            newComment.PublishDateTime = retrievedComment.PublishDateTime;
            return PartialView("_partial_article_comment", newComment);
        }

        [HttpPost]
        public void DeletePost(string postKey)
        {
         
            PublishingService.DeletePost(postKey);
        }

        [HttpPost]
        public void DeleteTweet(string tweetKey)
        {

            PublishingService.DeleteTweet(tweetKey);
        }

        [HttpPost]
        public void DeleteComment(string commentKey)
        {
    
            PublishingService.DeleteComment(commentKey);
        }

        [HttpPost]
        public void DeleteRetweet(string retweetKey)
        {

            PublishingService.DeleteRetweet(retweetKey);
        }

    }
}
