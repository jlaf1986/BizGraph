using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static class RecommendationService
    {
        public static CompleteProfile  GetSuggestionByBasicProfile(string requestorReferenceKey, int requestorAccountType, RecommendationType desiredRecommendationType)
        {
            BasicProfile requestorProfile = new BasicProfile { ReferenceKey=new Guid(requestorReferenceKey), ReferenceType=(AccountType) requestorAccountType  };
            
            CompleteProfile  newRecommendation = new CompleteProfile();

            switch (requestorProfile.ReferenceType)
            {
                case AccountType.UserAccount:
                    switch (desiredRecommendationType)
                    {
                        case RecommendationType.StrongTie:
                            newRecommendation = GraphRepository.GetWorkContactSuggestion(new Guid(requestorReferenceKey));
                            break;
                        case RecommendationType.WeakTie:
                            newRecommendation = GraphRepository.GetPartnershipContactSuggestion(new Guid(requestorReferenceKey));
                            break;
                        case RecommendationType.Community:
                            newRecommendation = GraphRepository.GetGroupSuggestion(new Guid(requestorReferenceKey));
                            break;
                    }
                    break;
                case AccountType.OrganizationAccount:
                    switch (desiredRecommendationType)
                    {
                        case RecommendationType.StrongTie:
                            newRecommendation = GraphRepository.GetSisterDivisionSuggestion(new Guid(requestorReferenceKey));
                            break;
                        case RecommendationType.WeakTie:
                            newRecommendation = GraphRepository.GetPartnerSuggestion(new Guid(requestorReferenceKey));
                            break;
                        case RecommendationType.Community:
                            newRecommendation = GraphRepository.GetAllianceSuggestion(new Guid(requestorReferenceKey));
                            break;
                    }
                    break;
            }

            return newRecommendation;
          
        }
    }
}
