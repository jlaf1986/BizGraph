
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using FHNWPrototype.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public class SecurityService
    {

        public bool UserAlreadyExists(string email)
        {
            return SecurityRepository.UserAlreadyExists(email);
        }

        public SystemAuthenticationTokenViewModel AttemptAuthentication(string email, string password)
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

        public void RegisterNewSystemAccount(string email, string password, bool isCorporateAccount)
        {
            SecurityRepository.RegisterNewSystemAccount(email, password, isCorporateAccount); 
        }

    }
}
