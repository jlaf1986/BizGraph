using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.DTOs;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class OrganizationAccountService
    {
 

        public static List<OrganizationAccountViewModel> GetAllOrganizationAccounts()
        {
            IEnumerable<OrganizationAccount> organizationAccounts = OrganizationAccountRepository.FindAll();

            List<OrganizationAccountViewModel> result = new List<OrganizationAccountViewModel>();
            foreach (OrganizationAccount item in organizationAccounts)
            {
                result.Add(Converters.ConvertOrganizationAccountToViewModel(item));
            }

            return result;
        }

        public static OrganizationAccountViewModel GetOrganizationAccountByKey(string organizationAccountKey)
        {
            

            OrganizationAccount organizationAccount = OrganizationAccountRepository.FindBy(new Guid(organizationAccountKey));

            return Converters.ConvertOrganizationAccountToViewModel(organizationAccount);
        }

        //public static OrganizationAccountViewModel GetOrganizationAccountByEmailSuffix(String emailSuffix)
        //{
             

        //    OrganizationAccount organizationAccount = OrganizationAccountRepository.FindByEmailSuffix(emailSuffix);




        //    return Converters.ConvertOrganizationAccountToViewModel(organizationAccount);
        //}


        //public static OrganizationAccountViewModel GetOrganizationAccountByEmail(string organizationAccountEmail)
        //{
 
        //    OrganizationAccount organizationAccount = OrganizationAccountRepository.FindByEmail(organizationAccountEmail);
            
        //    return Converters.ConvertOrganizationAccountToViewModel(organizationAccount);
 
        //}

        public static OrganizationAccountViewModel GetOrganizationAccountByUserAccountKey(string userAccountKey)
        {

            OrganizationAccount organizationAccount = OrganizationAccountRepository.GetOrganizationAccountByUserAccountKey(new Guid(userAccountKey));

            return Converters.ConvertOrganizationAccountToViewModel(organizationAccount);

        }

 
        public static List<PartnershipStateInfoViewModel> GetAllPartnershipsByOrganizationAccountKey(string organizationAccountKey)
        {

            IEnumerable<PartnershipStateInfoDTO> partnerships = OrganizationAccountRepository.GetAllPartnershipsByOrganizationAccountKey(new Guid(organizationAccountKey));

            List<PartnershipStateInfoViewModel> result = new List<PartnershipStateInfoViewModel>();

            foreach (PartnershipStateInfoDTO item in partnerships)
            {
                PartnershipStateInfoViewModel itemview = new PartnershipStateInfoViewModel();

                BasicProfileViewModel senderBasicProfile = new BasicProfileViewModel();
                senderBasicProfile.ReferenceKey = item.Sender.Key.ToString();
                senderBasicProfile.AccountType = AccountType.OrganizationAccount;
                CompleteProfileViewModel senderCompleteProfile = new CompleteProfileViewModel();
                senderCompleteProfile.BasicProfile = senderBasicProfile;

                BasicProfileViewModel receiverBasicProfile = new BasicProfileViewModel();
                receiverBasicProfile.ReferenceKey = item.Receiver.Key.ToString();
                receiverBasicProfile.AccountType = AccountType.OrganizationAccount;
                CompleteProfileViewModel receiverCompleteProfile = new CompleteProfileViewModel();
                receiverCompleteProfile.BasicProfile = receiverBasicProfile;


                //if you are the receiver you only need info from the sender
                //if you are the sender you only need info from the receiver

                if (item.Receiver.Key.ToString() == organizationAccountKey)
                {
                    senderCompleteProfile.BasicProfile.ReferenceKey = item.Sender.Key.ToString();
                    senderCompleteProfile.BasicProfile.AccountType = AccountType.OrganizationAccount;
                    senderCompleteProfile.FullName = item.Sender.Name;
                    senderCompleteProfile.Description1 = item.Sender.Description;
                    senderCompleteProfile.Description2 = item.Sender.Organization.Name;

                }
                else
                {
                    receiverCompleteProfile.BasicProfile.ReferenceKey = item.Receiver.Key.ToString();
                    receiverCompleteProfile.BasicProfile.AccountType = AccountType.OrganizationAccount;
                    receiverCompleteProfile.FullName = item.Receiver.Name;
                    receiverCompleteProfile.Description1 = item.Receiver.Description;
                    receiverCompleteProfile.Description2 = item.Receiver.Organization.Name;
                }

                itemview.Receiver = receiverCompleteProfile;
                itemview.Sender = senderCompleteProfile;
                itemview.PartnershipAction = item.Action;
                //itemview.ReceiverEmail = item.Receiver.Email;
                //itemview.SenderEmail = item.Sender.Email;
                result.Add(itemview);
            }


            return result;
        }



        public static List<AllianceMembershipStateInfoViewModel> GetAllAllianceMembershipsByOrganizationAccountKey(string organizationAccountKey)
        {
          

            IEnumerable<AllianceMembershipStateInfo> allianceMemberships = OrganizationAccountRepository.GetAllAllianceMembershipsByOrganizationKey(new Guid(organizationAccountKey));

            List<AllianceMembershipStateInfoViewModel> result = new List<AllianceMembershipStateInfoViewModel>();

            foreach (AllianceMembershipStateInfo item in allianceMemberships)
            {
                AllianceMembershipStateInfoViewModel itemview = new AllianceMembershipStateInfoViewModel();
                itemview.Action = item.AllianceMembershipAction;
                itemview.ActionDateTime = item.GetActionDateTime();
                itemview.RequestedAllianceKey = item.AllianceRequested.Key.ToString();
                itemview.RequestorOrganizationAccountKey = item.OrganizationRequestor.Key.ToString();
                result.Add(itemview);
            }
            return result;
        }



        public static PartnershipStateInfoViewModel GetPartnershipBetweenOrganizationAccountsByKeys(string organizationAccountKey1, string organizationAccountKey2)
        {

            PartnershipStateInfo partnership = OrganizationAccountRepository.GetPartnershipBetweenOrganizationAccounts(new Guid(organizationAccountKey1), new Guid(organizationAccountKey2));
            PartnershipStateInfoViewModel result = new PartnershipStateInfoViewModel();

            if (partnership != null)
            {

                PartnershipStateInfoViewModel itemview = new PartnershipStateInfoViewModel();
                BasicProfileViewModel senderBasicProfile = new BasicProfileViewModel();
                senderBasicProfile.ReferenceKey = partnership.Sender.Key.ToString();
                senderBasicProfile.AccountType = AccountType.OrganizationAccount;
                CompleteProfileViewModel senderCompleteProfile = new CompleteProfileViewModel();
                senderCompleteProfile.BasicProfile = senderBasicProfile;

                senderCompleteProfile.FullName = partnership.Sender.Name;
                senderCompleteProfile.Description1 = partnership.Sender.Description;
                senderCompleteProfile.Description2 = partnership.Sender.Organization.Name;

                BasicProfileViewModel receiverBasicProfile = new BasicProfileViewModel();
                receiverBasicProfile.ReferenceKey = partnership.Receiver.Key.ToString();
                receiverBasicProfile.AccountType = AccountType.UserAccount;

                CompleteProfileViewModel receiverCompleteProfile = new CompleteProfileViewModel();
                receiverCompleteProfile.BasicProfile = receiverBasicProfile;

                receiverCompleteProfile.FullName = partnership.Receiver.Name;
                receiverCompleteProfile.Description1 = partnership.Receiver.Description;
                receiverCompleteProfile.Description2 = partnership.Receiver.Organization.Name;

                result.ActionDateTime = partnership.ActionDateTime;
                result.PartnershipAction = partnership.Action;
                // result.ReceiverEmail = friendship.Receiver.Email;
                //result.SenderEmail = friendship.Sender.Email;
            }
            else
            {
                result.PartnershipAction = PartnershipAction.New;
            }
            return result;
        }

        public static bool UpdatePartnershipStatus(string senderOrganizationAccountKey, string receiverOrganizationAccountKey, DateTime actionDateTime, PartnershipAction action)
        {
            bool success = OrganizationAccountRepository.UpdatePartnershipStatus(new Guid(senderOrganizationAccountKey), new Guid(receiverOrganizationAccountKey), actionDateTime, action);
            return success;

        }

        public static List<CompleteProfileViewModel> GetEmployeesOfOrganizationAccountByKey(string key)
        {
            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

            List<CompleteProfile> profilesFound = OrganizationAccountRepository.GetEmployeesOfOrganizationAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;
        }

        public static List<CompleteProfileViewModel> GetSisterDivisionsOfOrganizationAccountByKey(string key)
        {
            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

            List<CompleteProfile> profilesFound = OrganizationAccountRepository.GetSisterDivisionsOfOrganizationAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;
        }

        public static List<CompleteProfileViewModel> GetPartnersOfOrganizationAccountByKey(string key)
        {
            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

            List<CompleteProfile> profilesFound = OrganizationAccountRepository.GetPartnersOfOrganizationAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;
        }

        public static List<CompleteProfileViewModel> GetAlliancesOfOrganizationAccountByKey(string key)
        {

            List<CompleteProfileViewModel> result = new List<CompleteProfileViewModel>();

            List<CompleteProfile> profilesFound = OrganizationAccountRepository.GetAlliancesOfOrganizationAccountByKey(new Guid(key));

            foreach (CompleteProfile item in profilesFound)
            {
                result.Add(new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey = item.BasicProfile.ReferenceKey.ToString(), AccountType = item.BasicProfile.ReferenceType }, FullName = item.FullName, Description1 = item.Description1, Description2 = item.Description2 });
            }

            return result;

        }

    }
}
