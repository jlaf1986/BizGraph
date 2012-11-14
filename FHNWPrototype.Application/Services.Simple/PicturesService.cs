using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class PicturesService
    {


        public static byte[] GetAvatarPictureByBasicProfile(string referenceKey, int accountType)
        {
            byte[] pictureFound = null;
            AccountType  thisType =  (AccountType) accountType;
            BasicProfile profile = new BasicProfile { ReferenceKey=new Guid(referenceKey) ,  ReferenceType=thisType  };

            if (profile.ReferenceType == AccountType.OrganizationAccount)
            {
                pictureFound = OrganizationAccountRepository.GetAvatarPictureByOrganizationKey(profile.ReferenceKey);
            }
            if(profile.ReferenceType== AccountType.UserAccount)
            {
              //  UserAccountRepository userAccountRepository = new UserAccountRepository();
                pictureFound = UserAccountRepository.GetProfilePictureByAccountKey(profile.ReferenceKey);
            }
            if (profile.ReferenceType == AccountType.Group)
            {
                pictureFound = GroupRepository.GetProfilePictureByGroupKey(profile.ReferenceKey);
            }
            if (profile.ReferenceType == AccountType.Alliance)
            {
                pictureFound = AllianceRepository.GetProfilePictureByAllianceKey(profile.ReferenceKey);
            }
            return pictureFound;
        }


        public static  byte[] GetHeaderPictureByBasicProfile(string referenceKey, int accountType)
        {

            byte[] pictureFound = null;


            BasicProfile profile = new BasicProfile() { ReferenceKey = new Guid(referenceKey), ReferenceType = (AccountType)accountType };

            if (profile.ReferenceType == AccountType.OrganizationAccount)
            {
                
                pictureFound = OrganizationRepository.GetHeaderPictureByOrganizationAccountKey(profile.ReferenceKey);

            }
            if(profile.ReferenceType== AccountType.UserAccount)
            {
                pictureFound = OrganizationRepository.GetHeaderPictureByUserAccountKey(profile.ReferenceKey);
            }
            if (profile.ReferenceType == AccountType.Group)
            {
                pictureFound = GroupRepository.GetHeaderPictureByGroupKey(profile.ReferenceKey);
            }
            if (profile.ReferenceType == AccountType.Alliance)
            {
                pictureFound = AllianceRepository.GetHeaderPictureByAllianceKey(profile.ReferenceKey);
            }
            return pictureFound;
        }

    }
}
