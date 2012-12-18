using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class GroupService
    {

        //private GroupRepository groupRepository;

        //public GroupService()
        //{
        //    //groupRepository = new GroupRepository();
        //}

        public static List<GroupViewModel> GetAllGroups()
        {
            

            IEnumerable<Group> groups = GroupRepository.FindAll();

            List<GroupViewModel> result = new List<GroupViewModel>();
       
            foreach (Group g in groups)
            {
                GroupViewModel groupview = new GroupViewModel();
                //groupview.Key = g.Key.ToString();
                //groupview.Name = g.Name;
                //groupview.Description = g.Description;
                groupview.Profile = new ServicesViewModels.CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=g.Key.ToString(), AccountType= AccountType.Group  }, FullName=g.Name, Description1=g.Description  };
                List<CompleteProfileViewModel> members = new List<ServicesViewModels.CompleteProfileViewModel>();
               
                foreach (GroupMembershipStateInfo membership in g.GroupMemberships)
                {

                    members.Add(new CompleteProfileViewModel{ BasicProfile=new ServicesViewModels.BasicProfileViewModel{ ReferenceKey= membership.RequestorAccount.Key.ToString(), AccountType=AccountType.UserAccount}, FullName=membership.RequestorAccount.User.FirstName + " " + membership.RequestorAccount.User.LastName }); 
                }
                groupview.Members = members;
                result.Add(groupview);
            }

            return result;
        }

        public static GroupViewModel GetGroupByKey(string groupKey)
        {
            
            Group group = GroupRepository.FindBy(new Guid(groupKey));

            GroupViewModel groupView = new GroupViewModel();
            //groupView.Key = group.Key.ToString();
            //groupView.Name = group.Name;
            //groupView.Description = group.Description;
            //Dictionary<string, string> members = new Dictionary<string, string>();
            //groupView.Members = members;

            groupView.Profile = new ServicesViewModels.CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = group.Key.ToString(), AccountType = AccountType.Group }, FullName = group.Name, Description1 = group.Description };
            List<CompleteProfileViewModel> members = new List<ServicesViewModels.CompleteProfileViewModel>();
               

            //groupView.Wall = new ContentStreamViewModel();
            //groupView.Wall.Posts = new List<PostViewModel>();

            foreach (GroupMembershipStateInfo membership in group.GroupMemberships)
            {

                members.Add(new CompleteProfileViewModel { BasicProfile = new ServicesViewModels.BasicProfileViewModel { ReferenceKey = membership.RequestorAccount.Key.ToString(), AccountType = AccountType.UserAccount }, FullName = membership.RequestorAccount.User.FirstName + " " + membership.RequestorAccount.User.LastName });
            }
            groupView.Members = members;


            //foreach (var post in group.Wall.Posts)
            //{
            //    PostViewModel thisPost = new PostViewModel();
            //    thisPost.Key = post.Key.ToString();
            //    //postView.AuthorKey = post.Author.ReferenceKey.ToString();
            //    //postView.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);
            //    var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

            //    thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };
                       
            //    thisPost.Text = post.Text;
            //    thisPost.TimeStamp = post.PublishDateTime;
            //    thisPost.Comments = new List<CommentViewModel>();
            //    foreach (var comment in post.Comments)
            //    {
            //        CommentViewModel thisComment = new CommentViewModel();
            //        thisComment.Key = comment.Key.ToString();
            //        thisComment.TimeStamp = comment.PublishDateTime;
            //        var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
            //        thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
                           
            //        thisComment.Text = comment.Text;
            //        thisPost.Comments.Add(thisComment);
            //    }
            //    groupView.Wall.Posts.Add(thisPost);
            //}

            return groupView;
        }


        public static List<GroupMembershipStateInfoViewModel> GetAllGroupMembershipsByGroupKey(string groupKey)
        {
          

            IEnumerable<GroupMembershipStateInfo> groupMemberships = GroupRepository.GetAllGroupMembershipsByGroupKey(new Guid(groupKey));

            List<GroupMembershipStateInfoViewModel> result = new List<GroupMembershipStateInfoViewModel>();

            foreach (GroupMembershipStateInfo item in groupMemberships)
            {
                GroupMembershipStateInfoViewModel itemview = new GroupMembershipStateInfoViewModel();
                itemview.Action = item.GroupMembershipAction;
                itemview.ActionDateTime = item.GetActionDateTime();
                itemview.RequestedGroupKey = item.RequestedGroup.Key.ToString();
                itemview.RequestorAccountKey = item.RequestorAccount.Key.ToString();
                result.Add(itemview);
            }

            return result;
        }

     

    }
}
