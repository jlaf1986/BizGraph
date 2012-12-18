using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.AllianceMemberships.Events;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.States
{
    public class AllianceMembershipAcceptedState : AllianceMembershipState 
    {


        private OrganizationAccount _requestorOrganization;
        private Alliance _requestedAlliance;
        private DateTime _submitDateTime = DateTime.Now;
        private IAllianceMembershipRepository _repository;

        public AllianceMembershipAcceptedState(OrganizationAccount thisOrganization, IAllianceMembershipRepository repository)
        {
            _requestorOrganization = thisOrganization;
            _submitDateTime = DateTime.Now;
            _repository = repository;
        }



        public override bool CanRequestAllianceMembershipRequestTo(Alliance allianceToRequest)
        {
            return false;
        }

        public override void RequestAllianceMembershipRequestTo(Alliance allianceToRequest)
        {
            throw new InvalidOperationException("Membership cannot be requested again");
        }

        public override bool CanOfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer)
        {
            return false;
        }

        public override void OfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer)
        {
            throw new InvalidOperationException("Membership cannot be offered anymore");
        }

        public override bool CanAllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            return false;
        }

        public override void AllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            throw new InvalidOperationException("Mambership cannot be allowed anymore");
        }

        public override bool CanAcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            return false;
        }

        public override void AcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            throw new InvalidOperationException("Membership has already been accepted");
        }

        public override bool CanRejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            return false;
        }

        public override void RejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            throw new InvalidOperationException("Membership has already been accepted");
        }

        public override bool CanCancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            //check conditions before
            //_requestedAlliance = contactToCancel;
            return true;
        }

        public override void CancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            if (CanCancelAllianceMembershipRequestOf(contactToCancel))
            {
                //persist with the repository
                //  _actionSentBy.Contacts.Remove(contactToCancel);
                //_repository.Save(_actionSentBy);
                //raise the final event
                DomainEvents.Raise(new AllianceMembershipCancelledEvent { MembershipCancelledBy = _requestedAlliance, DateTime = DateTime.Now, MembershipCancelledTo = contactToCancel });
            }
            else
            {
                throw new NotImplementedException("Relationship cannot be cancelled");
            }
        }

        public override AllianceMembershipAction GetAction()
        {
            return AllianceMembershipAction.Accept;
        }

        public override OrganizationAccount GetRequestorOrganization()
        {
            return _requestorOrganization;
        }

        public override Alliance GetRequestedAlliance()
        {
            return _requestedAlliance;
        }

        public override DateTime GetActionDateTime()
        {
            return _submitDateTime;
        }

    }
}
