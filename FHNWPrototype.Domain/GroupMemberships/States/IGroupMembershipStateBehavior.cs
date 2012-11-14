using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public interface IGroupMembershipStateBehavior
    {

        Boolean CanRequestGroupMembershipRequestTo(Group groupToRequest);
        void RequestGroupMembershipRequestTo(Group groupToRequest);

        Boolean CanOfferGroupMembershipRequestTo(UserAccount contactToOffer);
        void OfferGroupMembershipRequestTo(UserAccount contactToOffer);

        Boolean CanAllowGroupMembershipRequestTo(UserAccount contactToAllow);
        void AllowGroupMembershipRequestTo(UserAccount contactToAllow);

        Boolean CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept);
        void AcceptGroupMembershipRequestFrom(UserAccount contactToAccept);

        Boolean CanRejectGroupMembershipRequestFrom(UserAccount contactToReject);
        void RejectGroupMembershipRequestFrom(UserAccount contactToReject);

        Boolean CanCancelGroupMembershipRequestOf(UserAccount contactToCancel);
        void CancelGroupMembershipRequestOf(UserAccount contactToCancel);

    }
}
