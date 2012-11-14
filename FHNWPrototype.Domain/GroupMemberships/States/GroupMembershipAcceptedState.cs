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
    public class GroupMembershipAcceptedState : GroupMembershipState 
    {

        private UserAccount _requestorAccount;
        private Group _requestedGroup;
        private DateTime _submitDateTime = DateTime.Now;
        private IGroupMembershipRepository _repository;

        public GroupMembershipAcceptedState(UserAccount thisPerson, IGroupMembershipRepository repository)
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
            throw new InvalidOperationException("Membership cannot be offered anymore");
        }

        public override bool CanAllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            return false;
        }

        public override void AllowGroupMembershipRequestTo(UserAccount contactToAllow)
        {
            throw new InvalidOperationException("Mambership cannot be allowed anymore");
        }

        public override bool CanAcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            return false;
        }

        public override void AcceptGroupMembershipRequestFrom(UserAccount contactToAccept)
        {
            throw new InvalidOperationException("Membership has already been accepted");
        }

        public override bool CanRejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            return false;
        }

        public override void RejectGroupMembershipRequestFrom(UserAccount contactToReject)
        {
            throw new InvalidOperationException("Membership has already been accepted");
        }

        public override bool CanCancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            //check conditions before
            //_receiver = contactToCancel;
            return true;
        }

        public override void CancelGroupMembershipRequestOf(UserAccount contactToCancel)
        {
            if (CanCancelGroupMembershipRequestOf(contactToCancel))
            {
                //persist with the repository
                //  _actionSentBy.Contacts.Remove(contactToCancel);
                //_repository.Save(_actionSentBy);
                //raise the final event
                DomainEvents.Raise(new GroupMembershipCancelledEvent { MembershipCancelledBy = _requestedGroup, DateTime = DateTime.Now, MembershipCancelledTo = contactToCancel });
            }
            else
            {
                throw new NotImplementedException("Relationship cannot be cancelled");
            }
        }

        public override GroupMembershipAction GetAction()
        {
            return GroupMembershipAction.Accept;
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
