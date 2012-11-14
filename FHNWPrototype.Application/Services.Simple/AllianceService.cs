using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class AllianceService
    {
        //AllianceRepository allianceRepository = new AllianceRepository();

      

        public static  AllianceViewModel GetAllianceByKey(String AllianceKey)
        {
        

            Alliance alliance = AllianceRepository.FindBy(new Guid(AllianceKey));

            AllianceViewModel allianceView = new AllianceViewModel();
          
            allianceView.Profile = new ServicesViewModels.CompleteProfileViewModel { BasicProfile = new ServicesViewModels.BasicProfileViewModel { ReferenceKey=alliance.Key.ToString(), AccountType= AccountType.Alliance  }, FullName=alliance.Name, Description1=alliance.Description  };
            //allianceView.Wall = new ContentStreamViewModel();
            //allianceView.Wall.Posts = new List<PostViewModel>();
            allianceView.Members = new List<CompleteProfileViewModel>();
            foreach (AllianceMembershipStateInfo membership in alliance.AllianceMemberships)
            {
                allianceView.Members.Add(new CompleteProfileViewModel { BasicProfile = new ServicesViewModels.BasicProfileViewModel { ReferenceKey=membership.OrganizationRequestor.Key.ToString(), AccountType= AccountType.OrganizationAccount  }, FullName=membership.OrganizationRequestor.Name , Description1=membership.OrganizationRequestor.Description  });
            }
            //foreach (var post in alliance.Wall.Posts)
            //{
            //    PostViewModel thisPost = new PostViewModel();
              
            //    var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);
               
            //    thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString() ,  AccountType = post.Author.ReferenceType  }, FullName = postAuthorProfile.FullName , Description1 = postAuthorProfile.Description1 , Description2 =postAuthorProfile.Description2  };
            //    thisPost.TimeStamp = post.PublishDateTime;
            //    thisPost.Text = post.Text;
            //    thisPost.Comments = new List<ServicesViewModels.CommentViewModel>();
            //    foreach (var comment in post.Comments)
            //    {
            //        CommentViewModel thisComment = new CommentViewModel();
            //        thisComment.TimeStamp = comment.PublishDateTime;
            //        var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
            //        thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString() , AccountType =commentAuthorProfile.BasicProfile.ReferenceType  }, FullName = commentAuthorProfile.FullName , Description1 = commentAuthorProfile.Description1 , Description2 = commentAuthorProfile.Description2  };
                           
            //        thisComment.Text = comment.Text;
            //        thisPost.Comments.Add(thisComment);
            //    }
            //    allianceView.Wall.Posts.Add(thisPost);
            //}

            return allianceView;
        }

        public static List<AllianceMembershipStateInfoViewModel> GetAllAllianceMembershipsByAllianceKey(string allianceKey)
        {
          

            IEnumerable<AllianceMembershipStateInfo> allianceMemberships = AllianceRepository.GetAllAllianceMembershipsByAllianceKey(new Guid(allianceKey));

            List<AllianceMembershipStateInfoViewModel> result = new List<AllianceMembershipStateInfoViewModel>();

            foreach (AllianceMembershipStateInfo item in allianceMemberships)
            {
                AllianceMembershipStateInfoViewModel itemview = new AllianceMembershipStateInfoViewModel();
                itemview.RequestedAllianceKey = item.Key.ToString();
                itemview.RequestorOrganizationAccountKey = item.OrganizationRequestor.Key.ToString();
                itemview.ActionDateTime = item.GetActionDateTime();
                itemview.Action = item.AllianceMembershipAction;
                result.Add(itemview);
            }

            return result;
        }

        public static byte[] GetHeaderPictureByKey(string allianceKey)
        {
            var result = AllianceRepository.GetHeaderPictureByAllianceKey(new Guid(allianceKey));
            return result;
        }

        public static byte[] GetProfilePictureByKey(string allianceKey)
        {
            var result = AllianceRepository.GetProfilePictureByAllianceKey(new Guid(allianceKey));
            return result;
        }


    }
}
