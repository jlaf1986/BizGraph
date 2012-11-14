using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Domain._Base.Accounts;
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
        public void LikePost(string postKey)
        {
            CompleteProfile myProfile = (CompleteProfile) Session["myProfile"];
 
            PublishingService.LikePost(myProfile.BasicProfile.ReferenceKey.ToString(), postKey);
        }
        [HttpPost]
        public void UnLikePost(string postKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            PublishingService.UnLikePost(myProfile.BasicProfile.ReferenceKey.ToString(), postKey);
        }
        [HttpPost]
        public void LikeComment(string commentKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            PublishingService.LikeComment(myProfile.BasicProfile.ReferenceKey.ToString(), commentKey);
        }
        [HttpPost]
        public void UnLikeComment(string commentKey)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            PublishingService.UnLikeComment(myProfile.BasicProfile.ReferenceKey.ToString(), commentKey);
        }

        [HttpPost]
        public PartialViewResult SubmitNewPost(string wallOwnerUserAccountKey, string text)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
          

            PostView newPost = new PostView();
            newPost.Key = PublishingService.SubmitNewPost(myProfile.BasicProfile.ReferenceKey.ToString(), wallOwnerUserAccountKey, text);
          
            newPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
            newPost.Comments = new List<CommentView>();
            newPost.Likes = 0;
            newPost.Text = text;
            newPost.TimeStamp = DateTime.Now.ToString();
            return PartialView("_partial_section_post", newPost);
        }
        [HttpPost]
        public PartialViewResult SubmitNewComment(string postKey, string text)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            

            CommentView newComment = new CommentView();
            newComment.Key = PublishingService.SubmitNewComment(myProfile.BasicProfile.ReferenceKey.ToString(), postKey, text);
            newComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };
          
            newComment.Likes = 0;
            newComment.Text = text;
            newComment.TimeStamp = DateTime.Now.ToString();
            return PartialView("_partial_article_comment", newComment);
        }

        [HttpPost]
        public void DeletePost(string postKey)
        {
         
            PublishingService.DeletePost(postKey);
        }

        [HttpPost]
        public void DeleteComment(string commentKey)
        {
    
            PublishingService.DeleteComment(commentKey);
        }
    }
}
