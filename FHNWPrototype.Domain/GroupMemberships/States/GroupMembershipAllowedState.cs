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
    public class GroupMembershipAllowedState : GroupMembershipState 
    {


        private UserAccount _requestorAccount;
        private Group _requestedGroup;
        private DateTime _submitDateTime = DateTime.Now;
        private IGroupMembershipRepository _repository;

        public GroupMembershipAllowedState(UserAccount thisPerson, IGroupMembershipRepository repository)
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
            return false;
        }

        public override void AllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            throw new InvalidOperationException("Membership cannot be allowed again");
        }

        public override bool CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            //check conditions
           // _requestedGroup = contactToAccept;
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
            return true;
        }

        public override void CancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            if (CanCancelGroupMembershipRequestOf(contactToCancel))
            {
                DomainEvents.Raise(new GroupMembershipCancelledEvent { MembershipCancelledBy = _requestedGroup, DateTime = DateTime.Now, MembershipCancelledTo = contactToCancel });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be cancelled");
            }
        }

        public override GroupMembershipAction GetAction()
        {
            return GroupMembershipAction.Allow;
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
