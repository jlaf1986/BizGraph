using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
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
    public class RetrieverController : Controller
    {

        public FileContentResult GetAvatarPictureByBasicProfile(string key, AccountType  accountType)
        {
           // PicturesService picturesService = new PicturesService();
            //BasicProfile profile = new BasicProfile { ReferenceKey=new Guid(key), ReferenceType=(AccountType) accountType};
            byte[] pictureFound = PicturesService.GetAvatarPictureByBasicProfile(key, (int)accountType );
            return File(pictureFound, "image/jpg");

        }

        public FileContentResult GetHeaderPictureByBasicProfile(string key, AccountType accountType)
        {
          //  PicturesService picturesService = new PicturesService();
            //BasicProfile profile = new BasicProfile { ReferenceKey = new Guid(key), ReferenceType = (AccountType)accountType };
            byte[] pictureFound = PicturesService.GetHeaderPictureByBasicProfile(key, (int)accountType);
            return File(pictureFound, "image/png");

        }

        
        public PartialViewResult GetWorkContactSuggestion(string requestorReferenceKey)
        {
            
            CompleteProfile profile = new CompleteProfile();
            CompleteProfileView profileView = null;
            profile = RecommendationService.GetWorkContactSuggestionByBasicProfile(requestorReferenceKey);
           // profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E205"), ReferenceType = AccountType.UserAccount }, FullName = "Larry Page", Description1 = "", Description2 = "" };
            if (profile != null)
            {
                 profileView = new CompleteProfileView() { BasicProfile = new BasicProfileView { ReferenceKey = profile.BasicProfile.ReferenceKey.ToString(), AccountType = profile.BasicProfile.ReferenceType }, FullName = profile.FullName, Description1 = profile.Description1, Description2 = profile.Description2 };
            }
            return PartialView("_partial_complete_profile",profileView);
        }

        public PartialViewResult GetPartnershipContactSuggestion(string requestorReferenceKey)
        {
           
            CompleteProfile profile = new CompleteProfile();
            CompleteProfileView profileView = null;
           profile = RecommendationService.GetPartnershipContactSuggestionByBasicProfile(requestorReferenceKey);
          //  profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid("BCBCCE0E-7C9F-4386-98AA-1458F308E203"), ReferenceType = AccountType.UserAccount }, FullName = "Allie Opper", Description1 = "", Description2 = "" };
           if (profile != null)
           {
               profileView = new CompleteProfileView() { BasicProfile = new BasicProfileView { ReferenceKey = profile.BasicProfile.ReferenceKey.ToString(), AccountType = profile.BasicProfile.ReferenceType }, FullName = profile.FullName, Description1 = profile.Description1, Description2 = profile.Description2 };
           }
            return PartialView("_partial_complete_profile", profileView);
        }

        public PartialViewResult GetGroupSuggestion(string requestorReferenceKey)
        {
          
            CompleteProfile profile = new CompleteProfile();
            CompleteProfileView profileView = null;
            profile = RecommendationService.GetGroupSuggestionByBasicProfile(requestorReferenceKey);
          //  profile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid("ACBCCE0E-7C9F-4386-99AA-1458F308EBB0"), ReferenceType = AccountType.Group  }, FullName = "Electric Providers Group", Description1 = "", Description2 = "" };
            if (profile != null)
            {
                profileView = new CompleteProfileView() { BasicProfile = new BasicProfileView { ReferenceKey = profile.BasicProfile.ReferenceKey.ToString(), AccountType = profile.BasicProfile.ReferenceType }, FullName = profile.FullName, Description1 = profile.Description1, Description2 = profile.Description2 };
            } 
            return PartialView("_partial_complete_profile", profileView);
        }

        //public PartialViewResult GetSisterDivisionSuggestion(string requestorReferenceKey, int requestorAccountType)
        //{
        //    CompleteProfile profile = new CompleteProfile();
        //    profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.StrongTie);
        //    return PartialView("_partial_complete_profile", profile);
        //}

        //public PartialViewResult GetPartnerSuggestion(string requestorReferenceKey, int requestorAccountType)
        //{
        //    CompleteProfile profile = new CompleteProfile();
        //    profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.WeakTie);
        //    return PartialView("_partial_complete_profile", profile);
        //}

        //public PartialViewResult GetAllianceSuggestion(string requestorReferenceKey, int requestorAccountType)
        //{
        //    CompleteProfile profile = new CompleteProfile();
        //    profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.Community);
        //    return PartialView("_partial_complete_profile", profile);
        //}


    }
}
