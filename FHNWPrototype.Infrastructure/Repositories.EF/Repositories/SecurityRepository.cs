using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static class SecurityRepository
    {
        //private FHNWPrototypeDB db = null;

        //public SecurityRepository()
        //{
        //    //db = new FHNWPrototypeDB();
        //}

        public static void RegisterNewSystemAccount(string email, string password, bool isCorporateAccount)
        {
            if (!UserAlreadyExists(email))
            {
                SystemAccount newAccount = new SystemAccount();
                newAccount.Email = email;
                newAccount.Password = password;
                //newAccount.Key = Guid.NewGuid();
               // newAccount.IsConfirmed = true;
                Guid newRecordGuid = Guid.NewGuid();
                if (isCorporateAccount)
                {
                    BasicProfile basicProfile = new BasicProfile() { ReferenceKey = newRecordGuid, ReferenceType = AccountType.OrganizationAccount };
                  //  CompleteProfile completeProfile = new CompleteProfile { BasicProfile=basicProfile  };
                    OrganizationAccount newOrganizationAccount = new OrganizationAccount() { Key=newRecordGuid, Name="OrganizationAccount" };
                    newAccount.Holder = basicProfile ;
                    using (var db = new FHNWPrototypeDB())
                    {
                        db.BasicProfiles.Add(basicProfile);
                        db.SystemAccounts.Add(newAccount);
                        db.OrganizationAccounts.Add(newOrganizationAccount);
                        
                        db.SaveChanges();
                    }
                }
                else
                {
                    BasicProfile basicProfile = new BasicProfile() { ReferenceKey = newRecordGuid, ReferenceType = AccountType.UserAccount  };
                   // CompleteProfile completeProfile = new CompleteProfile { BasicProfile=basicProfile  };
                    UserAccount newUserAccount = new UserAccount() { Key=newRecordGuid };
                    newAccount.Holder = basicProfile ;
                    using (var db = new FHNWPrototypeDB())
                    {
                        db.BasicProfiles.Add(basicProfile);
                        db.SystemAccounts.Add(newAccount);
                        db.UserAccounts.Add(newUserAccount);

                        db.SaveChanges();
                    }
                }
               // newAccount.IsCorporateAccount = isCorporateAccount;
               // newAccount.CreationDateTime = DateTime.Now;
                
                
            }
        }

        public static SystemAuthenticationToken AttemptAuthentication(string email, string password)
        {
            if (UserAlreadyExists(email))
            {
                SystemAccount result = null;
                using (var db = new FHNWPrototypeDB())
                {
                    result = db.SystemAccounts
                                            .Include("Holder")
                                            .Single(x => x.Email == email);

                    if (result.Password == password)
                    {
                        
                        SystemAuthenticationToken token = new SystemAuthenticationToken();
                        token.IsAuthenticated = true;
                        CompleteProfile completeProfile = new CompleteProfile();
                        completeProfile.BasicProfile = result.Holder;
                        
                        switch(result.Holder.ReferenceType)
                        {
                            case AccountType.UserAccount :
                                  var ua = db.UserAccounts
                                                        .Include("User")
                                                        .Include("OrganizationAccount.Organization")
                                                        .SingleOrDefault(x => x.Key == result.Holder.ReferenceKey);
                                  completeProfile.FullName = ua.User.FirstName + " " + ua.User.LastName;
                                  completeProfile.Description1 = ua.OrganizationAccount.Name;
                                  completeProfile.Description2 = ua.OrganizationAccount.Organization.Name;
                                break;
                            case AccountType.OrganizationAccount:
                                var oa = db.OrganizationAccounts 
                                               .Include("Organization")
                                               .SingleOrDefault(x => x.Key == result.Holder.ReferenceKey);
                                completeProfile.FullName = oa.Name;
                                completeProfile.Description1 = oa.Description;
                                  completeProfile.Description2 = oa.Organization.Name;
                                break;

                        }


                        token.MyProfile = completeProfile;
                        token.Email = email;
                        token.LastSuccesfulLogin = DateTime.Now;

                        return token;
                    }
                    else
                    {
                        SystemAuthenticationToken token = new SystemAuthenticationToken() { Email = email, IsAuthenticated = false };
                        return token;
                    }
                }
            }
            else
            {
                SystemAuthenticationToken token = new SystemAuthenticationToken() { Email = email, IsAuthenticated = false };
                return token;
            }
               
             
        }

        public static bool UserAlreadyExists(string email)
        {
            Boolean result=false ;
            using (var db = new FHNWPrototypeDB())
            {
                if (db.SystemAccounts.Count(x => x.Email == email) > 0)
                {
                    result = true;
                }
                return result;
            }

          
        }

        public static CompleteProfile  GetCompleteProfile(BasicProfile profile)
        {
            CompleteProfile  result = new CompleteProfile();
            BasicProfile basicProfile = new BasicProfile();
            result.BasicProfile=basicProfile;
            using (var db = new FHNWPrototypeDB())
            {
                if (profile.ReferenceType == AccountType.UserAccount)
                {
                    var ua = db.UserAccounts
                                            .Include("User")
                                            .Include("OrganizationAccount.Organization")
                                            .SingleOrDefault(x=> x.Key==profile.ReferenceKey);
                    result.BasicProfile.ReferenceKey = ua.Key;
                    result.BasicProfile.ReferenceType = AccountType.UserAccount;
                    result.FullName = ua.User.FirstName + " " + ua.User.LastName;
                    result.Description1 = ua.OrganizationAccount.Name;
                    result.Description2 = ua.OrganizationAccount.Organization.Name;
                }
                if (profile.ReferenceType == AccountType.OrganizationAccount)
                {
                    var oa = db.OrganizationAccounts
                                                    .Include("Organization")
                                                    .SingleOrDefault(x=> x.Key==profile.ReferenceKey);
                    result.BasicProfile.ReferenceKey = oa.Key;
                    result.BasicProfile.ReferenceType = AccountType.OrganizationAccount;
                    result.FullName = oa.Name;
                    result.Description1 = oa.Description;
                    result.Description2 = oa.Organization.Name;
                }
                if (profile.ReferenceType == AccountType.Group )
                {
                    var g = db.Groups.SingleOrDefault(x => x.Key == profile.ReferenceKey);
                    result.BasicProfile.ReferenceKey = g.Key;
                    result.BasicProfile.ReferenceType = AccountType.Group;
                    result.FullName = g.Name;
                    result.Description1 = g.Description;
                    result.Description2 = g.Description;
                }
                if (profile.ReferenceType == AccountType.Alliance )
                {
                    var al = db.Groups.SingleOrDefault(x => x.Key == profile.ReferenceKey);
                    result.BasicProfile.ReferenceKey = al.Key;
                    result.BasicProfile.ReferenceType = AccountType.Alliance;
                    result.FullName = al.Name;
                    result.Description1 = al.Description;
                    result.Description2 = al.Description;
                }

            }
            return result;
        }

    }
}
