using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public static class Converters
    {
        public static UserViewModel ConvertUserToViewModel(User user)
        {
            UserViewModel itemview = new UserViewModel();

            itemview.Key = user.Key.ToString();
            itemview.FirstName = user.FirstName;
            itemview.LastName = user.LastName;
            itemview.Longitude = user.GeoLocation.Longitude;
            itemview.Latitude = user.GeoLocation.Latitude;
            itemview.ProfilePicture = user.ProfilePicture;
            itemview.UserAccounts = new Dictionary<string, string>();
            itemview.UserAccounts.Clear();
            foreach (UserAccount subitem in user.UserAccounts)
            {
                itemview.UserAccounts.Add(subitem.Key.ToString(), subitem.Email);
            }
            return itemview;
        }


        public static UserAccountViewModel ConvertUserAccountToViewModel(UserAccount userAccount)
        {
            UserAccountViewModel itemview = new UserAccountViewModel();

            itemview.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=userAccount.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.UserAccount  }, FullName=userAccount.User.FirstName + " " + userAccount.User.LastName , Description1= userAccount.OrganizationAccount.Name, Description2=userAccount.OrganizationAccount.Organization.Name  };
            //itemview.UserAccountKey = userAccount.Key.ToString();
           
          //  itemview.UserName = userAccount.User.FirstName + " " + userAccount.User.LastName;
           // itemview.Organization = new KeyValuePair<string, string>(userAccount.OrganizationAccount.Organization.Key.ToString(), userAccount.OrganizationAccount.Organization.Name);
            itemview.Email = userAccount.Email;
           // itemview.UserKey = userAccount.User.Key.ToString();
            //itemview.OrganizationAccount = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { },  }; new KeyValuePair<string, string>(userAccount.OrganizationAccount.Key.ToString(), userAccount.OrganizationAccount.Name);
            itemview.WorkContacts = new List<CompleteProfileViewModel>();
            itemview.PartnershipContacts = new List<CompleteProfileViewModel>();
            itemview.Groups = new List<CompleteProfileViewModel>();
            //itemview.WorkContacts.Clear();
            //itemview.PartnershipContacts.Clear();
            //itemview.Groups.Clear();
            itemview.Wall = new ContentStreamViewModel();
            itemview.Wall.Posts = new List<PostViewModel>();
            if (userAccount.GroupMemberships.Count>0)
            {
                foreach (var subitem in userAccount.GroupMemberships)
                {
                    itemview.Groups.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=subitem.RequestedGroup.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.Group  }, FullName=subitem.RequestedGroup.Name, Description1=subitem.RequestedGroup.Description  });

                }
            }
            if (userAccount.FriendshipsReceived.Count>0)
            {
                foreach (var subitem in userAccount.FriendshipsReceived)
                {
                    if (subitem.Receiver.OrganizationAccount.Key == subitem.Sender.OrganizationAccount.Key)
                    {
                        itemview.WorkContacts.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey= subitem.Sender.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.UserAccount  }, FullName = subitem.Sender.User.FirstName + " " + subitem.Sender.User.LastName, Description1 = subitem.Sender.OrganizationAccount.Name, Description2 = subitem.Sender.OrganizationAccount.Organization.Name });
                    }
                    else
                    {
                        itemview.PartnershipContacts.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey= subitem.Sender.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.UserAccount  }, FullName = subitem.Sender.User.FirstName + " " + subitem.Sender.User.LastName, Description1 = subitem.Sender.OrganizationAccount.Name, Description2 = subitem.Sender.OrganizationAccount.Organization.Name });
                    }
                }
            }
            if (userAccount.FriendshipsRequested.Count>0)
            {
                foreach (var subitem in userAccount.FriendshipsRequested)
                {
                    if (subitem.Receiver.OrganizationAccount.Key == subitem.Sender.OrganizationAccount.Key)
                    {
                        itemview.WorkContacts.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = subitem.Receiver.Key.ToString(), AccountType = Domain._Base.Accounts.AccountType.UserAccount }, FullName = subitem.Receiver.User.FirstName + " " + subitem.Receiver.User.LastName, Description1 = subitem.Receiver.OrganizationAccount.Name, Description2 = subitem.Receiver.OrganizationAccount.Organization.Name });
                    }
                    else
                    {
                        itemview.PartnershipContacts.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = subitem.Receiver.Key.ToString(), AccountType = Domain._Base.Accounts.AccountType.UserAccount }, FullName = subitem.Receiver.User.FirstName + " " + subitem.Receiver.User.LastName, Description1 = subitem.Receiver.OrganizationAccount.Name, Description2 = subitem.Receiver.OrganizationAccount.Organization.Name });
                    }
                }
            }

            if (userAccount.Wall.Posts.Count>0)
            {
                foreach (var post in userAccount.Wall.Posts)
                {
                    PostViewModel thisPost = new PostViewModel();
                    thisPost.Key = post.Key.ToString();
                    //thisPost.AuthorKey = post.Author.ReferenceKey.ToString();
                    //thisPost.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                    var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                    thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };
                       
                    thisPost.Text = post.Text;
                    thisPost.TimeStamp = post.PublishDateTime;
                    thisPost.Comments = new List<CommentViewModel>();
                    if (post.PostLikes != null)
                    {
                        thisPost.Likes = post.PostLikes.Count();
                    }
                    else{
                        thisPost.Likes = 0;
                    }
                    foreach (var comment in post.Comments)
                    {
                        CommentViewModel thisComment = new CommentViewModel();
                        thisComment.Key = comment.Key.ToString();
                        //thisComment.AuthorKey = comment.Author.ReferenceKey.ToString();
                        //thisComment.AuthorName = SecurityRepository.GetCompleteProfile(comment.Author.ReferenceKey);

                        var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
                        thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
                       

                        thisComment.Text = comment.Text;
                        thisComment.TimeStamp = comment.PublishDateTime;
                        if (comment.CommentLikes != null)
                        {
                            thisComment.Likes = comment.CommentLikes.Count();
                        }
                        else
                        {
                            thisComment.Likes = 0;
                        }
                        thisPost.Comments.Add(thisComment);
                    }
                    itemview.Wall.Posts.Add(thisPost);
                }
            }

            return itemview;
        }

        public static OrganizationAccountViewModel ConvertOrganizationAccountToViewModel(OrganizationAccount organizationAccount)
        {
            OrganizationAccountViewModel organizationAccountView = new OrganizationAccountViewModel();
            //organizationAccountView.Key = organizationAccount.Key.ToString();
            //organizationAccountView.Name = organizationAccount.Name;
            //organizationAccountView.Description = organizationAccount.Description;
            organizationAccountView.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=organizationAccount.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.OrganizationAccount  }, FullName=organizationAccount.Name , Description1= organizationAccount.Organization.Name , Description2= organizationAccount.Organization.Name  };
            organizationAccountView.Organization = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=organizationAccount.Organization.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.Organization }, FullName=organizationAccount.Organization.Name, Description1=organizationAccount.Description, Description2=organizationAccount.Organization.Description    };
            organizationAccountView.Email = organizationAccount.Email;
            organizationAccountView.Location = new GeoLocationViewModel { Latitude = organizationAccount.Location.Latitude.ToString(), Longitude = organizationAccount.Location.Longitude.ToString() };
           
            organizationAccountView.Partners = new List<CompleteProfileViewModel>();
            organizationAccountView.Alliances = new List<CompleteProfileViewModel>();

            organizationAccountView.Employees = new List<CompleteProfileViewModel>();
            organizationAccountView.Wall = new ContentStreamViewModel();
            organizationAccountView.Wall.Posts = new List<PostViewModel>();
            if (organizationAccount.Employees != null)
            {
                foreach (var subitem in organizationAccount.Employees)
                {
                    organizationAccountView.Employees.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=subitem.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.UserAccount  }, FullName= subitem.User.FirstName + " " + subitem.User.LastName , Description1= subitem.OrganizationAccount.Name , Description2=subitem.OrganizationAccount.Organization.Name  });
                }
            }
            if (organizationAccount.AllianceMemberships.Count>0)
            {
                foreach (var subitem in organizationAccount.AllianceMemberships)
                {
                    organizationAccountView.Alliances.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=subitem.AllianceRequested.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.Alliance  }, FullName=subitem.AllianceRequested.Name , Description1=subitem.AllianceRequested.Description  });
                }
            }
            if (organizationAccount.PartnershipsReceived.Count>0)
            {
                foreach (var subitem in organizationAccount.PartnershipsReceived)
                {
                    organizationAccountView.Partners.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=subitem.Sender.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.OrganizationAccount  }, FullName=subitem.Sender.Name , Description1= subitem.Sender.Description  });
                }
            }
            if (organizationAccount.PartnershipsRequested.Count>0)
            {
                foreach (var subitem in organizationAccount.PartnershipsRequested)
                {
                    organizationAccountView.Partners.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=subitem.Receiver.Key.ToString(), AccountType= Domain._Base.Accounts.AccountType.OrganizationAccount  }, FullName= subitem.Receiver.Name, Description1= subitem.Receiver.Description  });
                }
            }
            
            if (organizationAccount.Wall.Posts.Count>0)
            {
                foreach (var post in organizationAccount.Wall.Posts)
                {
                    PostViewModel thisPost = new PostViewModel();
                    thisPost.Key = post.Key.ToString();
                    //postView.AuthorKey = post.Author.ReferenceKey.ToString();
                    //postView.AuthorName = SecurityRepository.GetCompleteProfile(post.Author.ReferenceKey);

                    var postAuthorProfile = SecurityRepository.GetCompleteProfile(post.Author);

                    thisPost.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = postAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = post.Author.ReferenceType }, FullName = postAuthorProfile.FullName, Description1 = postAuthorProfile.Description1, Description2 = postAuthorProfile.Description2 };
                  

                    thisPost.Text = post.Text;
                    thisPost.TimeStamp = post.PublishDateTime;
                    thisPost.Comments = new List<CommentViewModel>();
                    foreach (var comment in post.Comments)
                    {
                        CommentViewModel thisComment = new CommentViewModel();
                        thisComment.Key = comment.Key.ToString();
                        //thisComment.AuthorKey = comment.Author.ReferenceKey.ToString();
                        //thisComment.AuthorName = SecurityRepository.GetCompleteProfile(comment.Author.ReferenceKey);

                        var commentAuthorProfile = SecurityRepository.GetCompleteProfile(comment.Author);
                        thisComment.Author = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = commentAuthorProfile.BasicProfile.ReferenceKey.ToString(), AccountType = commentAuthorProfile.BasicProfile.ReferenceType }, FullName = commentAuthorProfile.FullName, Description1 = commentAuthorProfile.Description1, Description2 = commentAuthorProfile.Description2 };
                         

                        thisComment.Text = comment.Text;
                        thisComment.TimeStamp = comment.PublishDateTime;
                        thisPost.Comments.Add(thisComment);
                    }
                    organizationAccountView.Wall.Posts.Add(thisPost);
                }
            }
            else
            {
                organizationAccountView.Wall = new ContentStreamViewModel();
                organizationAccountView.Wall.Posts = new List<PostViewModel>();
            }

            return organizationAccountView;
        }

    }
}
