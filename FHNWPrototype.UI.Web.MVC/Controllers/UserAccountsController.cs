using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Controllers.UIViewModels.UserAccounts;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;
using Microsoft.AspNet.SignalR;
using FHNWPrototype.UI.Web.MVC.Signals;
using FHNWPrototype.Application.Controllers.UIViewModels.Chat;
using System.Web.Routing;
using FHNWPrototype.UI.Web.MVC.Controllers.UIViewModels._Global;
using System.IO;
using System.Web.Hosting;
using System.Web;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    [Authorize]
    public class UserAccountsController : Controller
    {
         
        public UserAccountsController()
        {
           
        }

        public ActionResult Index()
        {

            CompleteProfile  myProfile = (CompleteProfile)Session["myProfile"];

            UserAccountView accountView = new UserAccountView();
       
            accountView.IsThisMyOwnProfile = true;
            //accountView.WallOfThisProfile.Posts = new List<PostView>();
            //accountView.WallOfThisProfile.Tweets = new List<TweetView>();
            //accountView.WallOfThisProfile.Retweets = new List<RetweetView>();

            CompleteProfileView completeProfile = new CompleteProfileView();
            BasicProfileView basicProfile = new BasicProfileView();
            completeProfile.BasicProfile = basicProfile;
            basicProfile.ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString();
            basicProfile.AccountType = AccountType.UserAccount;
            completeProfile.FullName = myProfile.FullName;
            completeProfile.Description1 = myProfile.Description1;
            completeProfile.Description2 = myProfile.Description2;

            accountView.Profile = completeProfile;
 
            accountView.EmailOfThisProfile = User.Identity.Name;
       

            accountView.FoldersOfThisProfile = new Dictionary<string, string>();
            accountView.WallOfThisProfile = new ContentStreamView();
            accountView.WallOfThisProfile.Posts = new List<PostView>();
            accountView.WallOfThisProfile.Tweets = new List<TweetView>();
            accountView.WallOfThisProfile.Retweets = new List<RetweetView>();

            accountView.WorkContactsOfThisProfile = Converters.ConvertFromViewModelToView(UserAccountService.GetWorkContactsOfUserAccountByKey( myProfile.BasicProfile.ReferenceKey.ToString() ));
            accountView.PartnershipContactsOfThisProfile =Converters.ConvertFromViewModelToView(UserAccountService.GetPartnershipContactsOfUserAccountByKey( myProfile.BasicProfile.ReferenceKey.ToString()));
            accountView.GroupsOfThisProfile = Converters.ConvertFromViewModelToView(UserAccountService.GetGroupsOfUserAccountByKey(myProfile.BasicProfile.ReferenceKey.ToString()));

            //Im the owner and the viewer of the wall
            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();
            ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamAsNewsfeed(thisViewerKey,thisViewerKey);
            CompleteProfileViewModel myOrganizationAccount = OrganizationAccountService.GetOrganizationAccountProfileByEmployeeUserAccountKey(thisViewerKey);
            accountView.OrganizationAccountOfThisProfile = new CompleteProfileView { BasicProfile = new BasicProfileView  { ReferenceKey=myOrganizationAccount.BasicProfile.ReferenceKey, AccountType=myOrganizationAccount.BasicProfile.AccountType    }, FullName=myOrganizationAccount.FullName, Description1=myOrganizationAccount.Description1 , Description2=myOrganizationAccount.Description2  };
           // accountView.WallOfThisProfile = new ContentStreamView();
           // accountView.WallOfThisProfile.Posts = new List<PostView>();
            if (wallRetrieved.Posts.Count >0)
            {
        
                foreach (PostViewModel post in wallRetrieved.Posts)
                {
                    PostView thisPost = new PostView();
                    thisPost.Key = post.Key;
                    thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=post.Author.BasicProfile.ReferenceKey  , AccountType= post.Author.BasicProfile.AccountType  }, FullName=post.Author.FullName, Description1= post.Author.Description1 , Description2= post.Author.Description2  };
                    thisPost.PublishDateTime = post.PublishDateTime;
                    thisPost.Text = post.Text;
                    thisPost.Likes = post.Likes;
                    thisPost.ILikedIt = post.ILikedIt;
                       
                    thisPost.Comments = new List<CommentView>();
                    foreach (CommentViewModel comment in post.Comments)
                    {
                        CommentView thisComment = new CommentView();
                        thisComment.Key = comment.Key;
                        thisComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = comment.Author.BasicProfile.ReferenceKey, AccountType = comment.Author.BasicProfile.AccountType }, FullName = comment.Author.FullName, Description1 = comment.Author.Description1, Description2 = comment.Author.Description2 };
                        thisComment.Text = comment.Text;
                        thisComment.PublishDateTime = comment.PublishDateTime;
                        thisComment.Likes = comment.Likes;
                        thisComment.ILikedIt = comment.ILikedIt;
                        thisPost.Comments.Add(thisComment);
                    }

                    accountView.WallOfThisProfile.Posts.Add(thisPost);
                }
            }

            if (wallRetrieved.Tweets.Count > 0)
            {
                foreach (TweetViewModel tweet in wallRetrieved.Tweets)
                {
                    TweetView thisTweet = new TweetView();

                    thisTweet.Key = tweet.Key;
                    thisTweet.Text = tweet.Text;
                    thisTweet.PublishDateTime = tweet.PublishDateTime;
                    thisTweet.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = tweet.Author.BasicProfile.ReferenceKey, AccountType = tweet.Author.BasicProfile.AccountType }, FullName = tweet.Author.FullName, Description1 = tweet.Author.Description1, Description2 = tweet.Author.Description2 }; 
                    
                    accountView.WallOfThisProfile.Tweets.Add(thisTweet);
                }
            }

            if (wallRetrieved.Retweets.Count > 0)
            {
                foreach (RetweetViewModel retweet in wallRetrieved.Retweets)
                {
                    RetweetView thisRetweet = new RetweetView();

                    thisRetweet.RetweetKey = retweet.RetweetKey;
                    thisRetweet.TweetKey = retweet.TweetKey;

                    thisRetweet.Text = retweet.Text;
                    thisRetweet.PublishDateTime = retweet.PublishDateTime;
                    thisRetweet.TweetPublishDateTime = retweet.TweetPublishDateTime.ToString();

                    thisRetweet.RetweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = retweet.RetweetAuthor.BasicProfile.ReferenceKey, AccountType = retweet.RetweetAuthor.BasicProfile.AccountType }, FullName = retweet.RetweetAuthor.FullName, Description1 = retweet.RetweetAuthor.Description1, Description2 = retweet.RetweetAuthor.Description2 };

                    thisRetweet.TweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = retweet.TweetAuthor.BasicProfile.ReferenceKey, AccountType = retweet.TweetAuthor.BasicProfile.AccountType }, FullName = retweet.TweetAuthor.FullName, Description1 = retweet.TweetAuthor.Description1, Description2 = retweet.TweetAuthor.Description2 }; 
                    
                    
                    accountView.WallOfThisProfile.Retweets.Add(thisRetweet);
                }
            }

            accountView.WallOfThisProfile.PublishedItems = new List<ISortingCapable>();

            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Posts);
            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Tweets);
            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Retweets);

             accountView.WallOfThisProfile.PublishedItems= accountView.WallOfThisProfile.PublishedItems.OrderByDescending(x => x.PublishDateTime).ToList();

             CompleteProfileView groupView = new CompleteProfileView() { BasicProfile = new BasicProfileView() { ReferenceKey = "ACBCCE0E-7C9F-4386-99AA-1458F308EBB0", AccountType = AccountType.Group }, FullName = "Electric Providers Group" };
             CompleteProfileView coworkerView = new CompleteProfileView() { BasicProfile = new BasicProfileView() { ReferenceKey = "BCBCCE0E-7C9F-4386-98AA-1458F308E205", AccountType = AccountType.UserAccount  }, FullName = "Larry Page" };
             CompleteProfileView partnerView = new CompleteProfileView() { BasicProfile = new BasicProfileView() { ReferenceKey = "BCBCCE0E-7C9F-4386-98AA-1458F308E203", AccountType = AccountType.UserAccount }, FullName = "Allie Opper" };

             accountView.GroupSuggestion = groupView;
             accountView.PartnerSuggestion = partnerView;
             accountView.CoworkerSuggestion = coworkerView;
       
            return View("Newsfeed",accountView);
        }

        public ActionResult UserAccount(string id)
        {
            CompleteProfile  myProfile = (CompleteProfile ) Session["myProfile"];

        
            UserAccountViewModel accountRetrieved = UserAccountService.GetUserAccountByKey(id);
       

            UserAccountView accountView = new UserAccountView();
          

            accountView.Profile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = accountRetrieved.Profile.BasicProfile.ReferenceKey  , AccountType = AccountType.UserAccount  }, FullName= accountRetrieved.Profile.FullName  , Description1=accountRetrieved.Profile.Description1 , Description2=accountRetrieved.Profile.Description2   };
 
            accountView.EmailOfThisProfile = accountRetrieved.Email;
    
            accountView.FoldersOfThisProfile = new Dictionary<string, string>();
            accountView.WallOfThisProfile = new ContentStreamView();
            accountView.WallOfThisProfile.Posts = new List<PostView>();
            accountView.WallOfThisProfile.Tweets = new List<TweetView>();
            accountView.WallOfThisProfile.Retweets = new List<RetweetView>();

            if (User.Identity.Name == accountRetrieved.Email)
            {
                accountView.IsThisMyOwnProfile = true;
            }
            else
            {
                FriendshipStateInfoViewModel friendship = UserAccountService.GetFriendshipBetweenUserAccountsByKeys(myProfile.BasicProfile.ReferenceKey.ToString() , accountRetrieved.Profile.BasicProfile.ReferenceKey );     
                
                switch (friendship.FriendshipAction)
                {
                    case FriendshipAction.Accept :
                        accountView.ShowFriendshipButtonForThisProfile = true;
                        accountView.EnableFriendshipButtonForThisProfile = true;
                        accountView.IsThisProfileAFriendOfMine = true;
                        accountView.FriendshipButtonActionNameForThisProfile = "CancelFriendshipWith";
                        accountView.FriendshipButtonControllerNameForThisProfile = "UserAccounts";
                        accountView.FriendshipButtonCaptionForThisProfile = "Cancel Friendship";
                        break;
                  
                    case FriendshipAction.Request :

                        if (friendship.Sender.BasicProfile.ReferenceKey == myProfile.BasicProfile.ReferenceKey.ToString())
                        {
                            //if the viewer is the one that sent the request
                            accountView.ShowFriendshipButtonForThisProfile = true;
                            accountView.EnableFriendshipButtonForThisProfile = false;
                            accountView.isWaitingForFriendshipResponse = true;
                            accountView.FriendshipButtonActionNameForThisProfile = "CancelRequestTo";
                            accountView.FriendshipButtonControllerNameForThisProfile = "UserAccounts";
                            accountView.FriendshipButtonCaptionForThisProfile = "Cancel Request";
                        }
                        else
                        {
                            //if the viewer is the one that received the request
                            accountView.ShowFriendshipButtonForThisProfile = true;
                            accountView.EnableFriendshipButtonForThisProfile = false;
                            accountView.FriendshipButtonActionNameForThisProfile = "Null";
                            accountView.FriendshipButtonControllerNameForThisProfile = "Null";
                            accountView.FriendshipButtonCaptionForThisProfile = "Request Received";
                        }
                  
                        break;

                    //case Domain.Friendships.States.FriendshipAction.New :
                    //case Domain.Friendships.States.FriendshipAction.Cancel :
                    //case Domain.Friendships.States.FriendshipAction.Reject :
                    default :
                        accountView.ShowFriendshipButtonForThisProfile = true;
                        accountView.EnableFriendshipButtonForThisProfile = true;
                        accountView.FriendshipButtonActionNameForThisProfile = "RequestFriendshipTo";
                        accountView.FriendshipButtonControllerNameForThisProfile = "UserAccounts";
                        accountView.FriendshipButtonCaptionForThisProfile = "Send Request";
                        break;
                        
                }
            }

            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();
            ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamAsProfileWall(id,thisViewerKey);


           


            if (wallRetrieved.Posts.Count>0)
            {
                if (wallRetrieved.Posts != null)
                {
                    accountView.WallOfThisProfile.Posts = new List<PostView>();
                    foreach (PostViewModel post in wallRetrieved.Posts)
                    {
                        PostView thisPost = new PostView();
                        thisPost.Key = post.Key;
                        thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=post.Author.BasicProfile.ReferenceKey , AccountType=post.Author.BasicProfile.AccountType  }, FullName= post.Author.FullName , Description1= post.Author.Description1 , Description2= post.Author.Description2  };
                     
                        thisPost.Text = post.Text;
                        thisPost.PublishDateTime = post.PublishDateTime;
                        thisPost.Likes = post.Likes;
                        thisPost.ILikedIt = post.ILikedIt;
                        thisPost.Comments = new List<CommentView>();
                        foreach (CommentViewModel comment in post.Comments)
                        {
                            CommentView thisComment = new CommentView();
                            thisComment.Key = comment.Key;
                            thisComment.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = comment.Author.BasicProfile.ReferenceKey, AccountType = comment.Author.BasicProfile.AccountType }, FullName = comment.Author.FullName, Description1 = comment.Author.Description1, Description2 = comment.Author.Description2 };
                         
                            thisComment.Text = comment.Text;
                            thisComment.ILikedIt = comment.ILikedIt;
                            thisComment.PublishDateTime = comment.PublishDateTime;
                            thisComment.Likes = comment.Likes;
                            thisPost.Comments.Add(thisComment);
                        }
                        accountView.WallOfThisProfile.Posts.Add(thisPost);
                    }
                }

            }
          


            if (wallRetrieved.Tweets.Count > 0)
            {
                foreach (TweetViewModel tweet in wallRetrieved.Tweets)
                {
                    TweetView thisTweet = new TweetView();

                    thisTweet.Key = tweet.Key;
                    thisTweet.Text = tweet.Text;
                    thisTweet.PublishDateTime = tweet.PublishDateTime;
                    thisTweet.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = tweet.Author.BasicProfile.ReferenceKey, AccountType = tweet.Author.BasicProfile.AccountType }, FullName = tweet.Author.FullName, Description1 = tweet.Author.Description1, Description2 = tweet.Author.Description2 };

                    accountView.WallOfThisProfile.Tweets.Add(thisTweet);
                }
            }

            if (wallRetrieved.Retweets.Count > 0)
            {
                foreach (RetweetViewModel retweet in wallRetrieved.Retweets)
                {
                    RetweetView thisRetweet = new RetweetView();

                    thisRetweet.RetweetKey = retweet.RetweetKey;
                    thisRetweet.TweetKey = retweet.TweetKey;

                    thisRetweet.Text = retweet.Text;
                    thisRetweet.PublishDateTime = retweet.PublishDateTime;
                    thisRetweet.TweetPublishDateTime = retweet.TweetPublishDateTime.ToString();

                    thisRetweet.RetweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = retweet.RetweetAuthor.BasicProfile.ReferenceKey, AccountType = retweet.RetweetAuthor.BasicProfile.AccountType }, FullName = retweet.RetweetAuthor.FullName, Description1 = retweet.RetweetAuthor.Description1, Description2 = retweet.RetweetAuthor.Description2 };

                    thisRetweet.TweetAuthor = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = retweet.TweetAuthor.BasicProfile.ReferenceKey, AccountType = retweet.TweetAuthor.BasicProfile.AccountType }, FullName = retweet.TweetAuthor.FullName, Description1 = retweet.TweetAuthor.Description1, Description2 = retweet.TweetAuthor.Description2 };


                    accountView.WallOfThisProfile.Retweets.Add(thisRetweet);
                }
            }

            accountView.WorkContactsOfThisProfile = Converters.ConvertFromViewModelToView(UserAccountService.GetWorkContactsOfUserAccountByKey(accountRetrieved.Profile.BasicProfile.ReferenceKey  ));
            accountView.PartnershipContactsOfThisProfile = Converters.ConvertFromViewModelToView(UserAccountService.GetPartnershipContactsOfUserAccountByKey(accountRetrieved.Profile.BasicProfile.ReferenceKey));
            accountView.GroupsOfThisProfile = Converters.ConvertFromViewModelToView(UserAccountService.GetGroupsOfUserAccountByKey(accountRetrieved.Profile.BasicProfile.ReferenceKey));


            accountView.WallOfThisProfile.PublishedItems = new List<ISortingCapable>();

            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Posts);
            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Tweets);
            accountView.WallOfThisProfile.PublishedItems.AddRange(accountView.WallOfThisProfile.Retweets);

            accountView.WallOfThisProfile.PublishedItems = accountView.WallOfThisProfile.PublishedItems.OrderByDescending(x => x.PublishDateTime).ToList();

            
            return View("MyWall", accountView);
        }

        public ActionResult Friendships()
        {

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
 
            UserAccountViewModel accountRetrieved = UserAccountService.GetUserAccountByKey(myProfile.BasicProfile.ReferenceKey.ToString());
           
            FriendshipsView friendshipsView = new FriendshipsView();

            friendshipsView.AcceptedWorkContacts = new List<CompleteProfileView>();
            friendshipsView.AcceptedPartnershipContacts = new List<CompleteProfileView>();

            friendshipsView.RequestorWorkContacts = new List<CompleteProfileView>();
            friendshipsView.RequestorPartnershipContacts = new List<CompleteProfileView>();

            friendshipsView.WorkContactSuggestion = new List<CompleteProfileView>();
            friendshipsView.PartnershipContactSuggestion = new List<CompleteProfileView>();
            friendshipsView.GroupSuggestion = new List<CompleteProfileView>();


            List<FriendshipStateInfoViewModel> friendships = UserAccountService.GetAllFriendshipsByUserAccountKey(accountRetrieved.Profile.BasicProfile.ReferenceKey );

            foreach (var friendship in friendships)
            {
 
                
                CompleteProfileView profile = new CompleteProfileView();

                if (friendship.FriendshipAction == FriendshipAction.Accept)
                {
                  
                    //am i the receiver?
                    if (accountRetrieved.Profile.BasicProfile.ReferenceKey  == friendship.Receiver.BasicProfile.ReferenceKey)
                    {

                        //is a coworker?
                        if (myProfile.Description1  == friendship.Sender.Description1)
                        {

                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Sender.BasicProfile.ReferenceKey );

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Sender.BasicProfile.ReferenceKey, AccountType=AccountType.UserAccount  };
                            profile.FullName  = friendship.Sender.FullName;
                            profile.Description1  = organizationAccountVM.Profile.FullName ;
                            profile.Description2  = organizationAccountVM.Organization.FullName;
                            friendshipsView.AcceptedWorkContacts.Add(profile);
                        }
                        else
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Sender.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName;
                            friendshipsView.AcceptedPartnershipContacts.Add(profile);
                        }
                    }
                    else
                    {
                        //is a coworker?
                        if (myProfile.Description1  == friendship.Receiver.Description1)
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey=friendship.Receiver.BasicProfile.ReferenceKey , AccountType= AccountType.UserAccount  };
                            profile.FullName = friendship.Receiver.FullName;
                            profile.Description1  = organizationAccountVM.Profile.FullName ;
                            profile.Description2  = organizationAccountVM.Organization.FullName ;
                            friendshipsView.AcceptedWorkContacts.Add(profile);
                        }
                        else
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Receiver.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName ;
                            friendshipsView.AcceptedPartnershipContacts.Add(profile);
                        }
                    }

                }
                if(friendship.FriendshipAction== FriendshipAction.Request)
                {
                    //am i the receiver?
                    if (accountRetrieved.Profile.BasicProfile.ReferenceKey  == friendship.Receiver.BasicProfile.ReferenceKey)
                    {

                        //is a coworker?
                        if (myProfile.Description1 == friendship.Sender.Description1)
                        {

                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Sender.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName ;
                            friendshipsView.RequestorWorkContacts.Add(profile);
                        }
                        else
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Sender.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName ;
                            friendshipsView.RequestorPartnershipContacts.Add(profile);
                        }
                    }
                    else
                    {
                        //is a coworker?
                        if (myProfile.Description1 == friendship.Receiver.Description1)
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Receiver.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName ;
                            friendshipsView.RequestorWorkContacts.Add(profile);
                        }
                        else
                        {
                            OrganizationAccountViewModel organizationAccountVM = OrganizationAccountService.GetOrganizationAccountByUserAccountKey(friendship.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = friendship.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.UserAccount };
                            profile.FullName = friendship.Receiver.FullName;
                            profile.Description1 = organizationAccountVM.Profile.FullName ;
                            profile.Description2 = organizationAccountVM.Organization.FullName ;
                            friendshipsView.RequestorPartnershipContacts.Add(profile);
                        }
                    }
                }

            }

            return View(friendshipsView);
        }
 

        [HttpPost]
        public JsonResult RequestFriendshipTo(string key)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

           
            bool success = UserAccountService.UpdateFriendshipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, FriendshipAction.Request);
        
            string message;
            if (success)
            {
                message  = "Request has been sent";
            }
            else
            {
                message = "Request could not be sent";
            }
            return Json(new { message= message, success=success  });      
        }

        [HttpPost]
        public JsonResult  CancelRequestTo(string key)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            bool success = UserAccountService.UpdateFriendshipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, FriendshipAction.Cancel );
            string message;
            if (success)
            {
                message = "Request has been sent";
            }
            else
            {
                message = "Request could not be sent";
            }
            return Json(new { message = message, success = success });     
        }

        [HttpPost]
        public JsonResult CancelFriendshipWith(string key)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            bool success = UserAccountService.UpdateFriendshipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, FriendshipAction.Cancel);
            string message;
            if (success)
            {
                message = "Request has been sent";
            }
            else
            {
                message = "Request could not be sent";
            }
            return Json(new { message = message, success = success });     
        }

        [HttpPost]
        public JsonResult  AcceptRequestFrom(string key)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            bool success = UserAccountService.UpdateFriendshipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, FriendshipAction.Accept );
            string message;
            if (success)
            {
                message = "Request has been sent";
            }
            else
            {
                message = "Request could not be sent";
            }
            return Json(new { message = message, success = success });       
        }

        [HttpPost]
        public JsonResult RejectRequestFrom(string key)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            var success = UserAccountService.UpdateFriendshipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, FriendshipAction.Reject );
            string message;
            if (success)
            {
                message = "Request has been sent";
            }
            else
            {
                message = "Request could not be sent";
            }
            return Json(new { message = message, success = success });        
        }

        public ActionResult Chat()
        {

           
            return View();
        }

        [HttpPost]
        public JsonResult PostMessageToChat(string message)
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            var context = GlobalHost.ConnectionManager.GetHubContext<Chat>();

            ChatMessageView cmv = new ChatMessageView();

            cmv.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=myProfile.BasicProfile.ReferenceKey.ToString(), AccountType=myProfile.BasicProfile.ReferenceType  }, FullName=myProfile.FullName  };
            cmv.Text = message;
            cmv.TimeStamp = DateTime.Now.ToString();

            StringBuilder newMessage = new StringBuilder();

           RouteValueDictionary routeParameters =  new RouteValueDictionary(new {id = cmv.Author.BasicProfile.ReferenceKey});
             
            newMessage.AppendLine(@"<article class=""message"">");
            newMessage.AppendLine(@"<img src=""" + Url.Action("GetAvatarPictureByBasicProfile", "Retriever", new { key = cmv.Author.BasicProfile.ReferenceKey , accountType =cmv.Author.BasicProfile.AccountType   }) + @""" alt=""picture""  class=""profile_picture_post"" />");
            newMessage.AppendLine("<h2>" +   HtmlHelper.GenerateLink(this.ControllerContext.RequestContext, System.Web.Routing.RouteTable.Routes, cmv.Author.FullName , "Default", "UserAccount", "UserAccounts", routeParameters , null) + "</h2>");
            newMessage.AppendLine("<p>" + cmv.Text  + "</p>" );
            newMessage.AppendLine(@"<nav class=""actionlinks""><ul><li>" + cmv.TimeStamp  + "</li></ul></nav>" );
            newMessage.AppendLine("</article>");

            //string transformedView = PartialView("_partial_artiche_chat_message", cmv).ToString();

            
            context.Clients.All.Received(newMessage.ToString());

            var result = new { success = true };

            return Json(result);
            //return PartialView("_partial_artiche_chat_message",cmv);
        }

        [HttpGet]
        public ActionResult Graph()
        {
//            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

  //          CompleteProfileView thisProfile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 };

            return View("_standalone_visualization");
        }

        [HttpGet]
        public ActionResult visualizationdata(string format)
        {
           // string path = System.AppDomain.CurrentDomain.BaseDirectory.Substring(0, System.AppDomain.CurrentDomain.BaseDirectory.Length - 1);
           // FileInfo  file= new FileInfo(Path.Combine( HostingEnvironment.ApplicationPhysicalPath , @"Content\visualizationdata.json"));
            //FileInfo file = new FileInfo(Path.Combine(HttpRuntime.AppDomainAppPath, @"Content\visualizationdata.json"));
           // FileInfo file = new FileInfo(Path.Combine(path, @"Content\visualizationdata.json"));
           // FileInfo file = new FileInfo(Server.MapPath("/Content/visualizationdata.json"));
            FileInfo file = new FileInfo(Server.MapPath("~/Content/visualizationdata2.json"));
            return File(file.Open(FileMode.Open, FileAccess.Read), "application/json", "visualizationdata2.json");
        }

    }
}
