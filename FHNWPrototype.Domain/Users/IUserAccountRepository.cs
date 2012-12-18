using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.DTOs;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Users
{
    public interface IUserAccountRepository
    {
        void Add(UserAccount entity);
        IEnumerable<UserAccount> FindBy(Query query);
        IEnumerable<UserAccount> FindBy(Query query, int index, int count);
        UserAccount FindBy(Guid key);
        UserAccount FindByEmail(string email);
        IEnumerable<FriendshipStateInfoDTO> GetAllFriendshipsByAccountKey(Guid key);
        IEnumerable<GroupMembershipStateInfo> GetAllGroupMembershipsByAccountKey(Guid key);
        FriendshipStateInfo GetFriendshipBetweenUserAccounts(Guid userAccountKey1, Guid userAccountKey2);
        List<CompleteProfile> GetGroupsOfUserAccountByKey(Guid key);
        byte[] GetHeaderPictureByUserAccountKey(Guid key);
        List<CompleteProfile> GetPartnershipContactsOfUserAccountByKey(Guid key);
        byte[] GetProfilePictureByAccountKey(Guid key);
        List<CompleteProfile> GetWorkContactsOfUserAccountByKey(Guid key);
        bool isPotentiallyRelatedWithThisViewerAsOrganization(string organizationAccountEmail);
        bool isPotentiallyRelatedWithThisViewerAsUser(string userAccountEmail);
        void Remove(UserAccount entity);
        void Save(UserAccount entity);
        void UpdateFriendshipStatus(Guid senderUserAccountKey, Guid receiverUserAccountKey, DateTime actionDateTime, FriendshipAction action);
    }
}
