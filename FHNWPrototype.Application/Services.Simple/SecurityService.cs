
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using FHNWPrototype.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class SecurityService
    {

        public static bool UserAlreadyExists(string email)
        {
            return SecurityRepository.UserAlreadyExists(email);
        }

        public static CompleteProfileViewModel GetCompleteProfileFromUserEmail(String userEmail)
        {
            CompleteProfileViewModel result = new CompleteProfileViewModel();

            CompleteProfile profile = SecurityRepository.GetCompleteProfileFromUserEmail(userEmail);

            result.BasicProfile = new BasicProfileViewModel { ReferenceKey=profile.BasicProfile.ReferenceKey.ToString(), AccountType=profile.BasicProfile.ReferenceType  };
            result.FullName = profile.FullName;
            result.Description1 = profile.Description1;
            result.Description2 = profile.Description2;

            return result;
        }

        public static CompleteProfileViewModel GetCompleteProfileFromBasicProfile(BasicProfile thisProfile)
        {
            CompleteProfileViewModel result = new CompleteProfileViewModel();

            CompleteProfile profile = SecurityRepository.GetCompleteProfile(thisProfile);

            result.BasicProfile = new BasicProfileViewModel { ReferenceKey = profile.BasicProfile.ReferenceKey.ToString(), AccountType = profile.BasicProfile.ReferenceType };
            result.FullName = profile.FullName;
            result.Description1 = profile.Description1;
            result.Description2 = profile.Description2;

            return result;
        }

        public static SystemAuthenticationTokenViewModel AttemptAuthentication(string email, string password)
        {
            SystemAuthenticationTokenViewModel systemAuthenticationTokenVM = new SystemAuthenticationTokenViewModel();
            SystemAuthenticationToken token = SecurityRepository.AttemptAuthentication(email, password);
            systemAuthenticationTokenVM.Email = token.Email;

            if (token.IsAuthenticated)
            {
                CompleteProfileViewModel completeProfile = new CompleteProfileViewModel();
                completeProfile.BasicProfile = new BasicProfileViewModel();
                completeProfile.BasicProfile.ReferenceKey = token.MyProfile.BasicProfile.ReferenceKey.ToString();
                completeProfile.BasicProfile.AccountType = token.MyProfile.BasicProfile.ReferenceType;
                completeProfile.FullName = token.MyProfile.FullName;
                completeProfile.Description1 = token.MyProfile.Description1;
                completeProfile.Description2 = token.MyProfile.Description2;

                systemAuthenticationTokenVM.MyProfile = completeProfile;
                systemAuthenticationTokenVM.IsAuthenticated = token.IsAuthenticated;
                systemAuthenticationTokenVM.LastSuccesfulLogin = token.LastSuccesfulLogin;
                
            }

            return systemAuthenticationTokenVM;
        }

        public static void RegisterNewSystemAccount(string email, string password, bool isCorporateAccount)
        {
            SecurityRepository.RegisterNewSystemAccount(email, password, isCorporateAccount); 
        }

        public static void RegisterLastCheck(BasicProfile profile)
        {
            SecurityRepository.RegisterLastCheck(profile);
        }

    }
}
