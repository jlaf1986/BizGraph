using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.DTOs;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static class UserAccountService
    {

        public static List<UserAccountViewModel> GetAllUserAccounts()
        {
           

            IEnumerable<UserAccount> accountsRetrieved = UserAccountRepository.FindAll();

            List<UserAccountViewModel> result = new List<UserAccountViewModel>();

            foreach (UserAccount item in accountsRetrieved)
            {
                result.Add(Converters.ConvertUserAccountToViewModel(item));
            }


            return result;

        }

        public static UserAccountViewModel GetUserAccountByKey(string userAccountKey)
        {

           // UserAccountRepository userAccountRepository = new UserAccountRepository();
            UserAccount accountRetrieved = UserAccountRepository.FindBy(new Guid(userAccountKey));


            return Converters.ConvertUserAccountToViewModel(accountRetrieved); ;
        }



        //public static UserAccountViewModel GetAccountByEmail(string email)
        //{
        //   // UserAccountRepository userAccountRepository = new UserAccountRepository();
        //    UserAccount accountRetrieved = UserAccountRepository.FindByEmail(email);

           
        //    return Converters.ConvertUserAccountToViewModel(accountRetrieved);
        //}

        public static List<CompleteProfileViewModel> GetWorkContactsOfUserAccountByKey(string key)
        {
            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

         //   UserAccountRepository userAccountRepository = new UserAccountRepository();

            List<CompleteProfile> profilesFound = UserAccountRepository.GetWorkContactsOfUserAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=item.BasicProfile.ReferenceKey.ToString(), AccountType=item.BasicProfile.ReferenceType }, FullName= item.FullName , Description1= item.Description1, Description2=item.Description2  });
            }

            return result;
        }

        public static List<CompleteProfileViewModel> GetPartnershipContactsOfUserAccountByKey(string key)
        {
    
            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

          //  UserAccountRepository userAccountRepository = new UserAccountRepository();

            List<CompleteProfile> profilesFound = UserAccountRepository.GetPartnershipContactsOfUserAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;
        }

        public static List<CompleteProfileViewModel> GetGroupsOfUserAccountByKey(string key)
        {

            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

         //   UserAccountRepository userAccountRepository = new UserAccountRepository();

            List<CompleteProfile> profilesFound = UserAccountRepository.GetGroupsOfUserAccountByKey(new Guid(key)); 

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;
 
        }

        public static List<FriendshipStateInfoViewModel> GetAllFriendshipsByUserAccountKey(string userAccountKey)
        {

          //  UserAccountRepository userAccountRepository = new UserAccountRepository();

            IEnumerable<FriendshipStateInfoDTO> friendships = UserAccountRepository.GetAllFriendshipsByAccountKey(new Guid(userAccountKey));

            List<FriendshipStateInfoViewModel> result = new List<FriendshipStateInfoViewModel>();

            foreach (FriendshipStateInfoDTO item in friendships)
            {
                FriendshipStateInfoViewModel itemview = new FriendshipStateInfoViewModel();

                BasicProfileViewModel senderBasicProfile = new BasicProfileViewModel();
                senderBasicProfile.ReferenceKey = item.Sender.Key.ToString();
                senderBasicProfile.AccountType = AccountType.UserAccount;
                CompleteProfileViewModel senderCompleteProfile = new CompleteProfileViewModel();
                senderCompleteProfile.BasicProfile = senderBasicProfile;

                BasicProfileViewModel receiverBasicProfile = new BasicProfileViewModel();
                receiverBasicProfile.ReferenceKey = item.Receiver.Key.ToString();
                receiverBasicProfile.AccountType = AccountType.UserAccount;
                CompleteProfileViewModel receiverCompleteProfile = new CompleteProfileViewModel();
                receiverCompleteProfile.BasicProfile = receiverBasicProfile;


                //if you are the receiver you only need info from the sender
                //if you are the sender you only need info from the receiver

                if (item.Receiver.Key.ToString() == userAccountKey)
                {
                    senderCompleteProfile.BasicProfile.ReferenceKey = item.Sender.Key.ToString();
                    senderCompleteProfile.BasicProfile.AccountType = AccountType.UserAccount;
                    senderCompleteProfile.FullName = item.Sender.User.FirstName + " " + item.Sender.User.LastName;
                    senderCompleteProfile.Description1 = item.Sender.OrganizationAccount.Name;
                    senderCompleteProfile.Description2 = item.Sender.OrganizationAccount.Organization.Name;
                     
                }
                else
                {
                    receiverCompleteProfile.BasicProfile.ReferenceKey = item.Receiver.Key.ToString();
                    receiverCompleteProfile.BasicProfile.AccountType = AccountType.UserAccount;
                    receiverCompleteProfile.FullName = item.Receiver.User.FirstName + " " + item.Receiver.User.LastName;
                    receiverCompleteProfile.Description1 = item.Receiver.OrganizationAccount.Name;
                    receiverCompleteProfile.Description2 = item.Receiver.OrganizationAccount.Organization.Name;
                }

                itemview.Receiver = receiverCompleteProfile;
                itemview.Sender = senderCompleteProfile;
                itemview.FriendshipAction = item.Action;
                //itemview.ReceiverEmail = item.Receiver.Email;
                //itemview.SenderEmail = item.Sender.Email;
                result.Add(itemview);
            }


            return result;
        }

        public static List<GroupMembershipStateInfoViewModel> GetAllGroupMembershipsByUserAccountKey(string key)
        {

           // UserAccountRepository userAccountRepository = new UserAccountRepository();

            IEnumerable<GroupMembershipStateInfo> memberships = UserAccountRepository.GetAllGroupMembershipsByAccountKey(new Guid(key));

            List<GroupMembershipStateInfoViewModel> result = new List<GroupMembershipStateInfoViewModel>();

            foreach (GroupMembershipStateInfo item in memberships)
            {
                GroupMembershipStateInfoViewModel itemview = new GroupMembershipStateInfoViewModel();
                itemview.Action = item.GroupMembershipAction;
                itemview.ActionDateTime = item.GetActionDateTime();
                itemview.RequestedGroupKey = item.RequestedGroup.Key.ToString();
                itemview.RequestorAccountKey = item.RequestorAccount.Key.ToString();

                result.Add(itemview);
            }

            return result;
        }

        public static FriendshipStateInfoViewModel GetFriendshipBetweenUserAccountsByKeys(string userAccountKey1, string userAccountKey2)
        {

           // UserAccountRepository userAccountRepository = new UserAccountRepository();

            FriendshipStateInfo friendship = UserAccountRepository.GetFriendshipBetweenUserAccounts(new Guid(  userAccountKey1) , new Guid( userAccountKey2) );
            FriendshipStateInfoViewModel result = new FriendshipStateInfoViewModel();

            if (friendship != null)
            {

                FriendshipStateInfoViewModel itemview = new FriendshipStateInfoViewModel();
                BasicProfileViewModel senderBasicProfile = new BasicProfileViewModel();
                senderBasicProfile.ReferenceKey = friendship.Sender.Key.ToString();
                senderBasicProfile.AccountType = AccountType.UserAccount;
                CompleteProfileViewModel senderCompleteProfile = new CompleteProfileViewModel();
                senderCompleteProfile.BasicProfile = senderBasicProfile;

                senderCompleteProfile.FullName = friendship.Sender.User.FirstName + " " + friendship.Sender.User.LastName;
                senderCompleteProfile.Description1 = friendship.Sender.OrganizationAccount.Name;
                senderCompleteProfile.Description2 = friendship.Sender.OrganizationAccount.Organization.Name;

                BasicProfileViewModel receiverBasicProfile = new BasicProfileViewModel();
                receiverBasicProfile.ReferenceKey = friendship.Receiver.Key.ToString();
                receiverBasicProfile.AccountType = AccountType.UserAccount;

                CompleteProfileViewModel receiverCompleteProfile = new CompleteProfileViewModel();
                receiverCompleteProfile.BasicProfile = receiverBasicProfile;

                receiverCompleteProfile.FullName = friendship.Receiver.User.FirstName + " " + friendship.Receiver.User.LastName;
                receiverCompleteProfile.Description1 = friendship.Receiver.OrganizationAccount.Name;
                receiverCompleteProfile.Description2 = friendship.Receiver.OrganizationAccount.Organization.Name;

                result.ActionDateTime = friendship.ActionDateTime;
                result.FriendshipAction = friendship.Action;
                // result.ReceiverEmail = friendship.Receiver.Email;
                //result.SenderEmail = friendship.Sender.Email;
            }
            else
            {
                result.FriendshipAction = FriendshipAction.New;
            }
            return result;
        }

        public static bool UpdateFriendshipStatus(string senderAccountKey, string receiverAccountKey, DateTime actionDateTime, FriendshipAction action)
        {
            //UserAccountRepository userAccountRepository = new UserAccountRepository();

           bool success = UserAccountRepository.UpdateFriendshipStatus(new Guid(senderAccountKey), new Guid(receiverAccountKey), actionDateTime, action);

           return success;
        }


    }
}
