using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.GroupMemberships.Events;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Groups;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public class GroupMembershipOfferedState : GroupMembershipState 
    {

        private UserAccount _requestorAccount;
        private Group _requestedGroup;
        private DateTime _submitDateTime = DateTime.Now;
        private IGroupMembershipRepository _repository;

        public GroupMembershipOfferedState(UserAccount thisPerson, IGroupMembershipRepository repository)
        {
            _requestorAccount = thisPerson;
            _submitDateTime = DateTime.Now;
            _repository = repository;
        }

        public override bool CanRequestGroupMembershipRequestTo(Group groupToRequest)
        {
            return false;
        }

        public override void RequestGroupMembershipRequestTo(Group groupToRequest)
        {
            throw new InvalidOperationException("Membership cannot be requested again");
        }

        public override bool CanOfferGroupMembershipRequestTo(UserAccount contactToOffer)
        {
            return false;
        }

        public override void OfferGroupMembershipRequestTo(UserAccount contactToOffer)
        {
            throw new InvalidOperationException("Membership cannot be offered again");
        }

        public override bool CanAllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            //_requestedGroup = contactToAllow;
            return true;
        }

        public override void AllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            if (CanAllowGroupMembershipRequestTo(contactToAllow))
            {
                DomainEvents.Raise(new GroupMembershipAllowedEvent { MembershipAllowedBy = _requestedGroup, DateTime = DateTime.Now, MembershipAllowedTo = contactToAllow });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be allowed");
            }
        }

        public override bool CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            //check conditions
            return true;
        }

        public override void AcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            if (CanAcceptGroupMembershipRequestFrom(contactToAccept))
            {
                DomainEvents.Raise(new GroupMembershipAcceptedEvent { MembershipAcceptedBy = _requestedGroup, DateTime = DateTime.Now, MembershipRequestedBy = contactToAccept });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be accepted");
            }
        }

        public override bool CanRejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            return true;
        }

        public override void RejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            if (CanRejectGroupMembershipRequestFrom(contactToReject))
            {
                DomainEvents.Raise(new GroupMembershipRejectedEvent { MembershipRejectedBy = _requestedGroup, DateTime = DateTime.Now, MembershipRequestedBy = contactToReject });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be rejected");
            }
        }

        public override bool CanCancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            return false;
        }

        public override void CancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            throw new InvalidOperationException("Membership cannot be cancelled before being accepted");
        }

        public override GroupMembershipAction GetAction()
        {
            return GroupMembershipAction.Offer;
        }

        public override UserAccount GetRequestor()
        {
            return _requestorAccount;
        }

        public override Group GetRequestedGroup()
        {
            return _requestedGroup;
        }

        public override DateTime GetActionDateTime()
        {
            return _submitDateTime;
        }
    }
}
