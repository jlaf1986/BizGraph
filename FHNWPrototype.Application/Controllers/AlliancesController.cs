using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Application.Controllers.UIViewModels.Alliances;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;



namespace FHNWPrototype.Application.Controllers.Controllers
{
    [Authorize]
    public class AlliancesController : Controller
    {
       // private AllianceService allianceService;

        public AlliancesController()
        {
           // allianceService = new AllianceService();
        }
         
        public ActionResult Alliance(string id)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            //"ACBCCE0E-7C9F-4386-98AA-1458F308E1B0"
            AllianceViewModel allianceRetrieved = AllianceService.GetAllianceByKey(id);
            AllianceView allianceView = new AllianceView();
        
            allianceView.Profile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=allianceRetrieved.Profile.BasicProfile.ReferenceKey , AccountType= Domain._Base.Accounts.AccountType.Alliance  }, FullName=allianceRetrieved.Profile.FullName, Description1=allianceRetrieved.Profile.Description1  };
          
            allianceView.WallOfThisProfile  = new ContentStreamView();
            allianceView.WallOfThisProfile.Posts = new List<PostView>();


            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();
            ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamByOwnerReferenceKey(id, thisViewerKey);


            allianceView.WallOfThisProfile = new ContentStreamView();
            allianceView.WallOfThisProfile.Posts = new List<PostView>();
            if (wallRetrieved.Posts.Count >0)
            {
        
                foreach (PostViewModel post in wallRetrieved.Posts)
                {
                    PostView thisPost = new PostView();
                    thisPost.Key = post.Key;
                    thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=post.Author.BasicProfile.ReferenceKey  , AccountType= post.Author.BasicProfile.AccountType  }, FullName=post.Author.FullName, Description1= post.Author.Description1 , Description2= post.Author.Description2  };
                    thisPost.TimeStamp = post.TimeStamp.ToString();
                    thisPost.Text = post.Text;
                    thisPost.Likes = post.Likes;
                       
                    thisPost.Comments = new List<CommentView>();
                    foreach (CommentViewModel comment in post.Comments)
                    {
                        CommentView thisComment = new CommentView();
                        thisComment.Key = comment.Key;
                        thisComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = comment.Author.BasicProfile.ReferenceKey, AccountType = comment.Author.BasicProfile.AccountType }, FullName = comment.Author.FullName, Description1 = comment.Author.Description1, Description2 = comment.Author.Description2 };
                        thisComment.Text = comment.Text;
                        thisComment.TimeStamp = comment.TimeStamp.ToString();
                        thisComment.Likes = comment.Likes;
                        thisPost.Comments.Add(thisComment);
                    }
                    allianceView.WallOfThisProfile.Posts.Add(thisPost);
                }
            }

            //if (allianceRetrieved.Wall != null)
            //{
            //    allianceView.WallOfThisProfile = new ContentStreamView();

            //    if (allianceRetrieved.Wall.Posts != null)
            //    {
            //        allianceView.WallOfThisProfile.Posts = new List<PostView>();
            //        foreach (PostViewModel post in allianceRetrieved.Wall.Posts)
            //        {
            //            PostView thisPost = new PostView();
                     
            //            thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = post.Author.BasicProfile.ReferenceKey, AccountType = post.Author.BasicProfile.AccountType }, FullName = post.Author.FullName, Description1 = post.Author.Description1, Description2 = post.Author.Description2 };
            //            thisPost.Key = post.Key;
                        
            //            thisPost.Text = post.Text;
            //            thisPost.TimeStamp = post.TimeStamp.ToString();
            //            thisPost.Comments = new List<CommentView>();
            //            foreach (CommentViewModel comment in post.Comments)
            //            {
            //                CommentView thisComment = new CommentView();
                          
            //                thisComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = comment.Author.BasicProfile.ReferenceKey, AccountType = comment.Author.BasicProfile.AccountType }, FullName = comment.Author.FullName, Description1 = comment.Author.Description1, Description2 = comment.Author.Description2 };
            //                thisComment.Key = comment.Key;
            //                thisComment.Text = comment.Text;
            //                thisComment.TimeStamp = comment.TimeStamp.ToString();
            //                thisPost.Comments.Add(thisComment);
            //            }
            //            allianceView.WallOfThisProfile.Posts.Add(thisPost);
            //        }
              //  }

          //  }
            

            allianceView.IsViewerAllowedToCollaborate = true;
            allianceView.Members = new List<CompleteProfileView>();
            foreach (CompleteProfileViewModel item in allianceRetrieved.Members)
            {
                allianceView.Members.Add(new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = item.BasicProfile.ReferenceKey, AccountType = item.BasicProfile.AccountType }, FullName = item.FullName, Description1 = item.Description1 });
            }

            return View(allianceView);
        }


    }
}
