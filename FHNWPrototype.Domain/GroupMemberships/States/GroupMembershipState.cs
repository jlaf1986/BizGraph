using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public abstract  class GroupMembershipState : IGroupMembershipStateBehavior , IGroupMembershipStateInfo 
    {
        public abstract bool CanRequestGroupMembershipRequestTo(Group groupToRequest);

        public abstract void RequestGroupMembershipRequestTo(Group groupToRequest);

        public abstract bool CanOfferGroupMembershipRequestTo(UserAccount contactToOffer);

        public abstract void OfferGroupMembershipRequestTo(UserAccount contactToOffer);

        public abstract bool CanAllowGroupMembershipRequestTo(UserAccount contactToAllow);

        public abstract void AllowGroupMembershipRequestTo(UserAccount contactToAllow);

        public abstract bool CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept);

        public abstract void AcceptGroupMembershipRequestFrom(UserAccount contactToAccept);

        public abstract bool CanRejectGroupMembershipRequestFrom(UserAccount contactToReject);

        public abstract void RejectGroupMembershipRequestFrom(UserAccount contactToReject);

        public abstract bool CanCancelGroupMembershipRequestOf(UserAccount contactToCancel);

        public abstract void CancelGroupMembershipRequestOf(UserAccount contactToCancel);

        public abstract GroupMembershipAction GetAction();

        public abstract UserAccount GetRequestor();

        public abstract Group GetRequestedGroup();

        public abstract DateTime GetActionDateTime();
    }
}
