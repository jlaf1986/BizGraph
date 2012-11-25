using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FHNWPrototype.Application.Controllers.UIViewModels.Organizations;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Application.Controllers.UIViewModels.OrganizationAccounts;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Application.Controllers.UIViewModels.Geographics;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class OrganizationAccountsController : Controller
    {
       // OrganizationAccountService organizationAccountService = new OrganizationAccountService();
        
        public OrganizationAccountsController()
        {
            
        }

        public ActionResult Index()
        {

            CompleteProfile myProfile = (CompleteProfile) Session["myProfile"];


            //OrganizationServiceFacade organizationService = new OrganizationServiceFacade(new OrganizationServiceProxy());

            //Dictionary<String, String> organizationAccountsFound = _organizationAccountServiceFacade.GetAllOrganizationAccounts();

            //OrganizationAccountsView organizationAccountsView = new OrganizationAccountsView();

            //organizationAccountsView.OrganizationAccounts = organizationAccountsFound;

            //return View(organizationAccountsView);

            //OrganizationServiceFacade organizationService = new OrganizationServiceFacade(new OrganizationServiceProxy());
            //"BCBCCE0E-7C9F-4386-98AA-1458F308E1C3"
            OrganizationAccountViewModel organizationAccountRetrieved = OrganizationAccountService.GetOrganizationAccountByKey(myProfile.BasicProfile.ReferenceKey.ToString());

            OrganizationAccountView organizationAccountView = new OrganizationAccountView();
            CompleteProfileView completeProfile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=myProfile.BasicProfile.ReferenceKey.ToString(), AccountType=myProfile.BasicProfile.ReferenceType  }, FullName=myProfile.FullName, Description1=myProfile.Description1  };

            organizationAccountView.Profile = completeProfile;
            
            organizationAccountView.Email = organizationAccountRetrieved.Email;

            organizationAccountView.IsThisMyOwnProfile = true;

            organizationAccountView.EmployeesOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetEmployeesOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));
            organizationAccountView.SisterDivisionsOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetSisterDivisionsOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));
            organizationAccountView.PartnersOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetPartnersOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));
            organizationAccountView.AlliancesOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetAlliancesOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));


            organizationAccountView.MyGeoLocation = new GeoLocationView { Latitude=organizationAccountRetrieved.Location.Latitude , Longitude=organizationAccountRetrieved.Location.Longitude  };

            organizationAccountView.WallOfThisProfile = new ContentStreamView();
            organizationAccountView.WallOfThisProfile.Posts = new List<PostView>();

            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();
            ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamAsNewsfeed(thisViewerKey, thisViewerKey);



        
            if (wallRetrieved.Posts.Count > 0)
            {

                foreach (PostViewModel post in wallRetrieved.Posts)
                {
                    PostView thisPost = new PostView();
                    thisPost.Key = post.Key;
                    thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = post.Author.BasicProfile.ReferenceKey, AccountType = post.Author.BasicProfile.AccountType }, FullName = post.Author.FullName, Description1 = post.Author.Description1, Description2 = post.Author.Description2 };
                    thisPost.TimeStamp = post.TimeStamp.ToString();
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
                        thisComment.ILikedIt = comment.ILikedIt;
                        thisComment.TimeStamp = comment.TimeStamp.ToString();
                        thisComment.Likes = comment.Likes;
                        thisPost.Comments.Add(thisComment);
                    }
                    organizationAccountView.WallOfThisProfile.Posts.Add(thisPost);
                }
            }
          
 
            Dictionary<string, string> coordinates = new Dictionary<string, string>();
            coordinates.Add("Partner1", "47.548807,7.587820");
            coordinates.Add("Partner2", "46.948432,7.440461");
            coordinates.Add("Partner3", "46.519595,6.632335");

          

            return View("Newsfeed",organizationAccountView);

        }

        public ActionResult OrganizationAccount(string id)
        {

            CompleteProfile myProfile = (CompleteProfile) Session["myProfile"];
            
            OrganizationAccountViewModel organizationAccountRetrieved = OrganizationAccountService.GetOrganizationAccountByKey(id);

            OrganizationAccountView organizationAccountView = new OrganizationAccountView();
            organizationAccountView.Profile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey , AccountType= AccountType.OrganizationAccount  }, FullName=organizationAccountRetrieved.Profile.FullName, Description1= organizationAccountRetrieved.Profile.Description1 , Description2=organizationAccountRetrieved.Profile.Description2  };
          
            organizationAccountView.Email = organizationAccountRetrieved.Email;

            //organizationAccountView.SisterDivisionsOfThisProfile = new List<CompleteProfileView>();
            //organizationAccountView.EmployeesOfThisProfile = Converters.ConvertFromViewModelToView(organizationAccountRetrieved.Employees);
            //organizationAccountView.PartnersOfThisProfile = Converters.ConvertFromViewModelToView(organizationAccountRetrieved.Partners);
            //organizationAccountView.AlliancesOfThisProfile = Converters.ConvertFromViewModelToView(organizationAccountRetrieved.Alliances);

            organizationAccountView.MyGeoLocation = new GeoLocationView() { Latitude=organizationAccountRetrieved.Location.Latitude , Longitude=organizationAccountRetrieved.Location.Longitude };

            organizationAccountView.WallOfThisProfile = new ContentStreamView();
            organizationAccountView.WallOfThisProfile.Posts = new List<PostView>();

            Dictionary<string, string> coordinates = new Dictionary<string, string>();
            coordinates.Add("Partner1", "47.548807,7.587820");
            coordinates.Add("Partner2", "46.948432,7.440461");
            coordinates.Add("Partner3", "46.519595,6.632335");

            organizationAccountView.MyGeoLocation = new GeoLocationView { Latitude = organizationAccountRetrieved.Location.Latitude, Longitude = organizationAccountRetrieved.Location.Longitude };

            organizationAccountView.WallOfThisProfile = new ContentStreamView();
            organizationAccountView.WallOfThisProfile.Posts = new List<PostView>();

            if (User.Identity.Name == organizationAccountRetrieved.Email)
            {
                organizationAccountView.IsThisMyOwnProfile = true;
            }
            else
            {
                PartnershipStateInfoViewModel partnership = OrganizationAccountService.GetPartnershipBetweenOrganizationAccountsByKeys(myProfile.BasicProfile.ReferenceKey.ToString(), organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey );

                switch (partnership.PartnershipAction)
                {
                    case PartnershipAction.Accept:
                        organizationAccountView.ShowPartnershipButtonForThisProfile = true;
                        organizationAccountView.EnablePartnershipButtonForThisProfile = true;
                        organizationAccountView.IsThisProfileAPartnerOfMine = true;
                        organizationAccountView.PartnershipButtonActionNameForThisProfile = "CancelPartnershipWith";
                        organizationAccountView.PartnershipButtonControllerNameForThisProfile = "OrganizationAccounts";
                        organizationAccountView.PartnershipButtonCaptionForThisProfile = "Cancel Partnership";
                        break;

                    case PartnershipAction.Request:

                        if (partnership.Sender.BasicProfile.ReferenceKey  == myProfile.BasicProfile.ReferenceKey.ToString())
                        {
                            //if the viewer is the one that sent the request
                            organizationAccountView.ShowPartnershipButtonForThisProfile = true;
                            organizationAccountView.EnablePartnershipButtonForThisProfile = false;
                            organizationAccountView.isWaitingForPartnershipResponse = true;
                            organizationAccountView.PartnershipButtonActionNameForThisProfile = "CancelRequestTo";
                            organizationAccountView.PartnershipButtonControllerNameForThisProfile = "OrganizationAccounts";
                            organizationAccountView.PartnershipButtonCaptionForThisProfile = "Cancel Request";
                        }
                        else
                        {
                            //if the viewer is the one that received the request
                            organizationAccountView.ShowPartnershipButtonForThisProfile = true;
                            organizationAccountView.EnablePartnershipButtonForThisProfile = false;
                            organizationAccountView.PartnershipButtonActionNameForThisProfile = "Null";
                            organizationAccountView.PartnershipButtonControllerNameForThisProfile = "Null";
                            organizationAccountView.PartnershipButtonCaptionForThisProfile = "Request Received";
                        }

                        break;

                    //case Domain.Friendships.States.FriendshipAction.New :
                    //case Domain.Friendships.States.FriendshipAction.Cancel :
                    //case Domain.Friendships.States.FriendshipAction.Reject :
                    default:
                        organizationAccountView.ShowPartnershipButtonForThisProfile = true;
                        organizationAccountView.EnablePartnershipButtonForThisProfile = true;
                        organizationAccountView.PartnershipButtonActionNameForThisProfile = "RequestPartnershipTo";
                        organizationAccountView.PartnershipButtonControllerNameForThisProfile = "OrganizationAccounts";
                        organizationAccountView.PartnershipButtonCaptionForThisProfile = "Send Request";
                        break;

                }
            }

            var thisViewerKey = myProfile.BasicProfile.ReferenceKey.ToString();

             ContentStreamViewModel wallRetrieved = PublishingService.GetContentStreamByOwnerReferenceKey(id,thisViewerKey);

             if (wallRetrieved.Posts.Count > 0)
             {
                 if (wallRetrieved.Posts != null)
                 {
                     organizationAccountView.WallOfThisProfile.Posts = new List<PostView>();
                     foreach (PostViewModel post in wallRetrieved.Posts)
                     {
                         PostView thisPost = new PostView();
                         thisPost.Key = post.Key;
                         thisPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = post.Author.BasicProfile.ReferenceKey, AccountType = post.Author.BasicProfile.AccountType }, FullName = post.Author.FullName, Description1 = post.Author.Description1, Description2 = post.Author.Description2 };

                         thisPost.Text = post.Text;
                         thisPost.TimeStamp = post.TimeStamp.ToString();
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
                         organizationAccountView.WallOfThisProfile.Posts.Add(thisPost);
                     }
                 }

             }
             else
             {
                 organizationAccountView.WallOfThisProfile = new ContentStreamView();
                 organizationAccountView.WallOfThisProfile.Posts = new List<PostView>();
             }

            organizationAccountView.EmployeesOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetEmployeesOfOrganizationAccountByKey( organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));
            organizationAccountView.SisterDivisionsOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetSisterDivisionsOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey ));
            organizationAccountView.PartnersOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetPartnersOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));
            organizationAccountView.AlliancesOfThisProfile = Converters.ConvertFromViewModelToView(OrganizationAccountService.GetAlliancesOfOrganizationAccountByKey(organizationAccountRetrieved.Profile.BasicProfile.ReferenceKey));


            return View("MyWall",organizationAccountView);
        }

      

        public ActionResult Partnerships()
        {

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            OrganizationAccountViewModel accountRetrieved = OrganizationAccountService.GetOrganizationAccountByKey(myProfile.BasicProfile.ReferenceKey.ToString());
          //  List<PartnershipStateInfoViewModel> partnerships = OrganizationAccountService.GetAllPartnershipsByOrganizationAccountKey(accountRetrieved.Profile.BasicProfile.ReferenceKey);


            PartnershipsView partnershipsView = new PartnershipsView();

            partnershipsView.AcceptedSisterDivisions = new List<CompleteProfileView>();
            partnershipsView.AcceptedPartners = new List<CompleteProfileView>();

            partnershipsView.RequestorSisterDivisions = new List<CompleteProfileView>();
            partnershipsView.RequestorPartners = new List<CompleteProfileView>();

            //partnershipsView.SisterDivisionSuggestion = new List<CompleteProfileView>();
            //partnershipsView.PartnerSuggestion = new List<CompleteProfileView>();
            //partnershipsView.AllianceSuggestion = new List<CompleteProfileView>();


            List<PartnershipStateInfoViewModel> partnerships = OrganizationAccountService.GetAllPartnershipsByOrganizationAccountKey(accountRetrieved.Profile.BasicProfile.ReferenceKey);

            foreach (var partnership in partnerships)
            {


                CompleteProfileView profile = new CompleteProfileView();

                if (partnership.PartnershipAction  == PartnershipAction.Accept)
                {

                    //am i the receiver?
                    if (accountRetrieved.Profile.BasicProfile.ReferenceKey  == partnership.Receiver.BasicProfile.ReferenceKey)
                    {

                        //is a coworker?
                        if (myProfile.Description2 == partnership.Sender.Description2)
                        {

                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Sender.FullName;
                            profile.Description1 = partnership.Sender.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.AcceptedSisterDivisions.Add(profile);
                        }
                        else
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Sender.FullName;
                            profile.Description1 = partnership.Sender.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.AcceptedPartners.Add(profile);
                        }
                    }
                    else
                    {
                        //is a coworker?
                        if (myProfile.Description2 == partnership.Receiver.Description2)
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount  };
                            profile.FullName = partnership.Receiver.FullName;
                            profile.Description1 = partnership.Receiver.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.AcceptedSisterDivisions.Add(profile);
                        }
                        else
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount  };
                            profile.FullName = partnership.Receiver.FullName;
                            profile.Description1 = partnership.Receiver.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.AcceptedPartners.Add(profile);
                        }
                    }

                }
                if (partnership.PartnershipAction == PartnershipAction.Request)
                {
                    //am i the receiver?
                    if (accountRetrieved.Profile.BasicProfile.ReferenceKey  == partnership.Receiver.BasicProfile.ReferenceKey)
                    {

                        //is a coworker?
                        if (myProfile.Description1 == partnership.Sender.Description1)
                        {

                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Sender.FullName;
                            profile.Description1 = partnership.Sender.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.RequestorSisterDivisions.Add(profile);
                        }
                        else
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Sender.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Sender.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Sender.FullName;
                            profile.Description1 = partnership.Sender.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.RequestorPartners.Add(profile);
                        }
                    }
                    else
                    {
                        //is a coworker?
                        if (myProfile.Description2 == partnership.Receiver.Description2)
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Receiver.FullName;
                            profile.Description1 = partnership.Receiver.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.RequestorSisterDivisions.Add(profile);
                        }
                        else
                        {
                            OrganizationViewModel organizationVM = OrganizationService.GetOrganizationByOrganizationAccountKey(partnership.Receiver.BasicProfile.ReferenceKey);

                            profile.BasicProfile = new BasicProfileView { ReferenceKey = partnership.Receiver.BasicProfile.ReferenceKey, AccountType = AccountType.OrganizationAccount };
                            profile.FullName = partnership.Receiver.FullName;
                            profile.Description1 = partnership.Receiver.Description1;
                            profile.Description2 = organizationVM.Profile.FullName;
                            partnershipsView.RequestorPartners.Add(profile);
                        }
                    }
                }

            }

            return View(partnershipsView);
        }

        [HttpPost]
        public JsonResult RequestPartnershipTo(string key)
        {
            // UserAccountViewModel receiver = userAccountService.GetUserAccountByKey(key);
            // FriendshipStateInfoViewModel lastFriendshipState = userAccountService.GetFriendshipBetweenUserAccounts(User.Identity.Name, receiver.Email);

            //userAccountService.UpdateFriendshipStatus(User.Identity.Name, receiver.AccountKey, DateTime.Now, FriendshipAction.Request);
            //PartnershipActionResultView partnershipActionResult = new PartnershipActionResultView();
            //partnershipActionResult.Message = "Request has been sent";
            //return PartialView("PartnershipActionResult", partnershipActionResult);
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            bool success = OrganizationAccountService.UpdatePartnershipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, PartnershipAction.Request);

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
        public JsonResult CancelRequestTo(string key)
        {
            //OrganizationAccountViewModel receiver = OrganizationAccountService.GetOrganizationAccountByKey(key);
            //PartnershipStateInfoViewModel lastPartnershipState = OrganizationAccountService.GetPartnershipBetweenUserAccounts(User.Identity.Name, receiver.Email);

            //// userAccountService.UpdateFriendshipStatus(User.Identity.Name, receiver.AccountKey, DateTime.Now, FriendshipAction.Cancel);
            //// return PartialView("FriendshipActionResult");
            ////// return "Request has been cancelled";
            //// //return Json(data, JsonRequestBehavior.AllowGet);
            //PartnershipActionResultView partnershipActionResult = new PartnershipActionResultView();
            //partnershipActionResult.Message = "Request has been cancelled";
            //return PartialView("PartnershipActionResult", partnershipActionResult);

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            bool success = OrganizationAccountService.UpdatePartnershipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, PartnershipAction.Cancel);
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
        public JsonResult CancelPartnershipWith(string key)
        {
            //OrganizationAccountViewModel receiver = OrganizationAccountService.GetOrganizationAccountByKey(key);
            //PartnershipStateInfoViewModel lastPartnershipState = OrganizationAccountService.GetPartnershipBetweenUserAccounts(User.Identity.Name, receiver.Email);

            ////  userAccountService.UpdateFriendshipStatus(User.Identity.Name, receiver.AccountKey, DateTime.Now, FriendshipAction.Cancel);
            ////return PartialView("FriendshipActionResult");
            //// return "Friendship has been cancelled";
            //// return Json(data, JsonRequestBehavior.AllowGet);
            //PartnershipActionResultView partnershipActionResult = new PartnershipActionResultView();
            //partnershipActionResult.Message = "Partnership has been cancelled";
            //return PartialView("PartnershipActionResult", partnershipActionResult);

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            bool success = OrganizationAccountService.UpdatePartnershipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, PartnershipAction.Cancel);
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
        public JsonResult AcceptRequestFrom(string key)
        {
            //OrganizationAccountViewModel receiver = OrganizationAccountService.GetOrganizationAccountByKey(key);
            //PartnershipStateInfoViewModel lastPartnershipState = OrganizationAccountService.GetPartnershipBetweenUserAccounts(User.Identity.Name, receiver.Email);

            ////  userAccountService.UpdateFriendshipStatus(User.Identity.Name, receiver.AccountKey, DateTime.Now, FriendshipAction.Accept);
            //// return  "Request has been accepted";
            ////  return Json(data, JsonRequestBehavior.AllowGet);
            ////   return PartialView("FriendshipActionResult");
            //PartnershipActionResultView partnershipActionResult = new PartnershipActionResultView();
            //partnershipActionResult.Message = "Request has been accepted";
            //return PartialView("PartnershipActionResult", partnershipActionResult);

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            bool success = OrganizationAccountService.UpdatePartnershipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, PartnershipAction.Accept);
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
            //OrganizationAccountViewModel receiver = OrganizationAccountService.GetOrganizationAccountByKey(key);
            //PartnershipStateInfoViewModel lastFriendshipState = OrganizationAccountService.GetPartnershipBetweenUserAccounts(User.Identity.Name, receiver.Email);

            //// userAccountService.UpdateFriendshipStatus(User.Identity.Name, receiver.AccountKey, DateTime.Now, FriendshipAction.Reject);
            ////  return  "Request has been rejected";
            //// return Json(data, JsonRequestBehavior.AllowGet);
            //// return PartialView("FriendshipActionResult");
            //PartnershipActionResultView friendshipActionResult = new PartnershipActionResultView();
            //friendshipActionResult.Message = "Request has been rejected";
            //return PartialView("PartnershipActionResult", friendshipActionResult);

            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];


            bool success = OrganizationAccountService.UpdatePartnershipStatus(myProfile.BasicProfile.ReferenceKey.ToString(), key, DateTime.Now, PartnershipAction.Reject);
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

    }
}
