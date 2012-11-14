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
            return File(pictureFound, "image/jpg");

        }

        public PartialViewResult GetWorkContactSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile  profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.StrongTie);
            return PartialView("_partial_complete_profile",profile);
        }

        public PartialViewResult GetPartnershipContactSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.WeakTie );
            return PartialView("_partial_complete_profile", profile);
        }

        public PartialViewResult GetGroupSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.Community);
            return PartialView("_partial_complete_profile", profile);
        }

        public PartialViewResult GetSisterDivisionSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.StrongTie);
            return PartialView("_partial_complete_profile", profile);
        }

        public PartialViewResult GetPartnerSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.WeakTie);
            return PartialView("_partial_complete_profile", profile);
        }

        public PartialViewResult GetAllianceSuggestion(string requestorReferenceKey, int requestorAccountType)
        {
            CompleteProfile profile = new CompleteProfile();
            profile = RecommendationService.GetSuggestionByBasicProfile(requestorReferenceKey, requestorAccountType, RecommendationType.Community);
            return PartialView("_partial_complete_profile", profile);
        }


    }
}
