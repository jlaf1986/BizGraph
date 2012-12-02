using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FHNWPrototype.Application.Controllers.UIViewModels.Groups;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;
 

namespace FHNWPrototype.Application.Controllers.Controllers
{
       [Authorize]
    public class GroupsController : Controller
    {


        public GroupsController()
        {
        }

        public ActionResult Group(string id)
        {

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            GroupViewModel groupRetrieved = GroupService.GetGroupByKey(id);

            GroupView groupView = new GroupView();


            groupView.Profile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=groupRetrieved.Profile.BasicProfile.ReferenceKey, AccountType=groupRetrieved.Profile.BasicProfile.AccountType  }, FullName=groupRetrieved.Profile.FullName, Description1=groupRetrieved.Profile.Description1   };


            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();
            ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamAsProfileWall(id, thisViewerKey);

            groupView.WallOfThisProfile = new ContentStreamView();
            groupView.WallOfThisProfile.Posts = new List<PostView>();
            if (wallRetrieved.Posts.Count > 0)
            {

                foreach (PostViewModel post in wallRetrieved.Posts)
                {
                    PostView thisPost = new PostView();
                    thisPost.Key = post.Key;
                    thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = post.Author.BasicProfile.ReferenceKey, AccountType = post.Author.BasicProfile.AccountType }, FullName = post.Author.FullName, Description1 = post.Author.Description1, Description2 = post.Author.Description2 };
                    thisPost.PublishDateTime = post.PublishDateTime;
                    thisPost.Text = post.Text;
                    thisPost.Likes = post.Likes;

                    thisPost.Comments = new List<CommentView>();
                    foreach (CommentViewModel comment in post.Comments)
                    {
                        CommentView thisComment = new CommentView();
                        thisComment.Key = comment.Key;
                        thisComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = comment.Author.BasicProfile.ReferenceKey, AccountType = comment.Author.BasicProfile.AccountType }, FullName = comment.Author.FullName, Description1 = comment.Author.Description1, Description2 = comment.Author.Description2 };
                        thisComment.Text = comment.Text;
                        thisComment.PublishDateTime = comment.PublishDateTime;
                        thisComment.Likes = comment.Likes;
                        thisPost.Comments.Add(thisComment);
                    }
                    groupView.WallOfThisProfile.Posts.Add(thisPost);
                }
            }

           
            groupView.IsViewerAllowedToCollaborate = true;
            groupView.Members = new List<CompleteProfileView>();
            foreach (CompleteProfileViewModel item in groupRetrieved.Members)
            {
                groupView.Members.Add(new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=item.BasicProfile.ReferenceKey, AccountType=item.BasicProfile.AccountType  }, FullName=item.FullName , Description1=item.Description1  });
            }
            return View(groupView);
        }

     

    }
}
