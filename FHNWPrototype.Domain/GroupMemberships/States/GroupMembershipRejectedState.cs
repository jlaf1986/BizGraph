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
    public class GroupMembershipRejectedState : GroupMembershipState 
    {

        private UserAccount _requestorAccount=null;
        private Group _requestedGroup=null;
        private DateTime _submitDateTime = DateTime.Now;
        private IGroupMembershipRepository _repository;

        public GroupMembershipRejectedState(UserAccount thisPerson, IGroupMembershipRepository repository)
        {
            _requestorAccount = thisPerson;
            _submitDateTime = DateTime.Now;
            _repository = repository;
        }

        public override bool CanRequestGroupMembershipRequestTo(Group groupToRequest)
        {
            //check conditions
            _requestedGroup = groupToRequest;
            return true;
        }

        public override void RequestGroupMembershipRequestTo(Group groupToRequest)
        {
            if (CanRequestGroupMembershipRequestTo(groupToRequest))
            {
                DomainEvents.Raise(new GroupMembershipRequestedEvent { MembershipRequestedBy = _requestorAccount, DateTime = DateTime.Now, MembershipRequestedTo = groupToRequest });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be requested anymore");
            }
        }

        public override bool CanOfferGroupMembershipRequestTo(UserAccount contactToOffer)
        {
            //check conditions
            //_receiver = contactToOffer;
            return true;
        }

        public override void OfferGroupMembershipRequestTo(UserAccount contactToOffer)
        {
            if (CanOfferGroupMembershipRequestTo(contactToOffer))
            {
                DomainEvents.Raise(new GroupMembershipOfferedEvent { MembershipOfferedBy = _requestedGroup, DateTime = DateTime.Now, MembershipOfferedTo = contactToOffer });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be offered");
            }
        }

        public override bool CanAllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            return false;
        }

        public override void AllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            throw new InvalidOperationException("Membership cannot be allowed");
        }

        public override bool CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            return false;
        }

        public override void AcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            throw new InvalidOperationException("Membership cannot be accepted");
        }

        public override bool CanRejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            return false;
        }

        public override void RejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            throw new InvalidOperationException("Membership cannot be rejected twice");
        }

        public override bool CanCancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            return false;
        }

        public override void CancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            throw new InvalidOperationException("Membership cannot be cancelled");
        }

        public override GroupMembershipAction GetAction()
        {
            return GroupMembershipAction.Reject;
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
