using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class GraphRepository
    {

        public static CompleteProfile GetCompleteProfile(BasicProfile basicProfile)
        {
            CompleteProfile completeProfile = new CompleteProfile();

           
            completeProfile.BasicProfile = basicProfile;

                switch (basicProfile.ReferenceType)
                {      
                    case AccountType.UserAccount:
                        using (var db = new FHNWPrototypeDB())
                        {
                            var ua = db.UserAccounts
                                                    .Include("OrganizationAccount.Organization")
                                                    .SingleOrDefault(x => x.Key == basicProfile.ReferenceKey);

                            completeProfile.BasicProfile = basicProfile;
                            completeProfile.FullName = ua.User.FirstName + " " + ua.User.LastName;
                            completeProfile.Description1 = ua.OrganizationAccount.Name;
                            completeProfile.Description2 = ua.OrganizationAccount.Organization.Name;

                        }
                        break;
                    case AccountType.OrganizationAccount:
                        using (var db = new FHNWPrototypeDB())
                        {
                            var oa = db.OrganizationAccounts 
                                                    .Include("Organization")
                                                    .SingleOrDefault(x => x.Key == basicProfile.ReferenceKey);

                            completeProfile.BasicProfile = basicProfile;
                            completeProfile.FullName = oa.Name;
                            completeProfile.Description1 = oa.Description;
                            completeProfile.Description2 = oa.Organization.Name;

                        }
                        break;
                    
                    case AccountType.Group:
                        using (var db = new FHNWPrototypeDB())
                        {
                            var group = db.Groups 
                                                    .SingleOrDefault(x => x.Key == basicProfile.ReferenceKey);

                            completeProfile.BasicProfile = basicProfile;
                            completeProfile.FullName = group.Name;
                            completeProfile.Description1 = group.Description;
                            //completeProfile.Description2 = oa.Organization.Name;

                        }
                        break;
                    case AccountType.Alliance:
                        using (var db = new FHNWPrototypeDB())
                        {
                            var alliance = db.Alliances
                                                    .SingleOrDefault(x => x.Key == basicProfile.ReferenceKey);

                            completeProfile.BasicProfile = basicProfile;
                            completeProfile.FullName = alliance.Name;
                            completeProfile.Description1 = alliance.Description;
                            //completeProfile.Description2 = oa.Organization.Name;

                        }
                        break;
                }

            return completeProfile;
        }

        public static CompleteProfile GetWorkContactSuggestion(Guid requestorUserAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.UserAccounts.Count();
                int randomIndex = new Random().Next(numberOfContacts);

               var ua = db.UserAccounts
                                        .Include("OrganizationAccount.Organization")
                                        .Include("User")
                                        .ElementAt(randomIndex);
               basicProfile.ReferenceKey = ua.Key;
               basicProfile.ReferenceType = AccountType.UserAccount;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = ua.User.FirstName + " " + ua.User.LastName;
                completeProfile.Description1 = ua.OrganizationAccount.Name;
                completeProfile.Description2 = ua.OrganizationAccount.Organization.Name;
                

            }
            return completeProfile;
        }

        public static CompleteProfile GetPartnershipContactSuggestion(Guid requestorAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.UserAccounts.Count();
                int randomIndex = new Random().Next(numberOfContacts);

                var ua = db.UserAccounts
                                         .Include("OrganizationAccount.Organization")
                                         .Include("User")
                                         .ElementAt(randomIndex);
                basicProfile.ReferenceKey = ua.Key;
                basicProfile.ReferenceType = AccountType.UserAccount;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = ua.User.FirstName + " " + ua.User.LastName;
                completeProfile.Description1 = ua.OrganizationAccount.Name;
                completeProfile.Description2 = ua.OrganizationAccount.Organization.Name;


            }
            return completeProfile;
        }

        public static CompleteProfile GetGroupSuggestion(Guid userAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.Groups.Count();
                int randomIndex = new Random().Next(numberOfContacts);

                var recommendedGroup = db.Groups 
                                         .ElementAt(randomIndex);
                basicProfile.ReferenceKey = recommendedGroup.Key;
                basicProfile.ReferenceType = AccountType.Group;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = recommendedGroup.Name;
                completeProfile.Description1 = recommendedGroup.Description;


            }
            return completeProfile;
        }

        public static CompleteProfile GetSisterDivisionSuggestion(Guid organizationAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.OrganizationAccounts.Count();
                int randomIndex = new Random().Next(numberOfContacts);

                var oa = db.OrganizationAccounts
                                         .Include("Organization")
                                         .ElementAt(randomIndex);
                basicProfile.ReferenceKey = oa.Key;
                basicProfile.ReferenceType = AccountType.UserAccount;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = oa.Name;
                completeProfile.Description1 = oa.Description;
                completeProfile.Description2 = oa.Organization.Name;


            }
            return completeProfile;
        }

        public static CompleteProfile GetPartnerSuggestion(Guid organizationAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.OrganizationAccounts.Count();
                int randomIndex = new Random().Next(numberOfContacts);

                var oa = db.OrganizationAccounts
                                         .Include("Organization")
                                         .ElementAt(randomIndex);
                basicProfile.ReferenceKey = oa.Key;
                basicProfile.ReferenceType = AccountType.UserAccount;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = oa.Name;
                completeProfile.Description1 = oa.Description;
                completeProfile.Description2 = oa.Organization.Name;


            }
            return completeProfile;
        }

        public static CompleteProfile GetAllianceSuggestion(Guid organizationAccountKey)
        {
            BasicProfile basicProfile = new BasicProfile();
            CompleteProfile completeProfile = new CompleteProfile();

            using (var db = new FHNWPrototypeDB())
            {
                var numberOfContacts = db.Alliances.Count();
                int randomIndex = new Random().Next(numberOfContacts);

                var recommendedAlliance = db.Alliances
                                         .ElementAt(randomIndex);
                basicProfile.ReferenceKey = recommendedAlliance.Key;
                basicProfile.ReferenceType = AccountType.Alliance;

                completeProfile.BasicProfile = basicProfile;
                completeProfile.FullName = recommendedAlliance.Name;
                completeProfile.Description1 = recommendedAlliance.Description;


            }
            return completeProfile;
        }

    }
}
