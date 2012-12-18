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
    public class AllianceMembershipCancelledState : AllianceMembershipState 
    {

        private OrganizationAccount _requestorOrganization;
        private Alliance _requestedAlliance;
        private DateTime _submitDateTime = DateTime.Now;
        private IAllianceMembershipRepository _repository;

        public AllianceMembershipCancelledState(OrganizationAccount thisPerson, IAllianceMembershipRepository repository)
        {
            _requestorOrganization = thisPerson;
            _submitDateTime = DateTime.Now;
            _repository = repository;
        }

        public override bool CanRequestAllianceMembershipRequestTo(Alliance allianceToRequest)
        {
            //check conditions
            _requestedAlliance = allianceToRequest;
            return true;
        }

        public override void RequestAllianceMembershipRequestTo(Alliance  allianceToRequest)
        {
            if (CanRequestAllianceMembershipRequestTo(allianceToRequest))
            {
                DomainEvents.Raise(new AllianceMembershipRequestedEvent { MembershipRequestedBy = _requestorOrganization, DateTime = DateTime.Now, MembershipRequestedTo = allianceToRequest });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be requested");
            }
        }

        public override bool CanOfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer)
        {
            //check conditions
            //_requestedAlliance = contactToOffer;
            return true;
        }

        public override void OfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer)
        {
            if (CanOfferAllianceMembershipRequestTo(contactToOffer))
            {
                DomainEvents.Raise(new AllianceMembershipOfferedEvent { MembershipOfferedBy = _requestedAlliance, DateTime = DateTime.Now, MembershipOfferedTo = contactToOffer });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be offered");
            }
        }

        public override bool CanAllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            return false;
        }

        public override void AllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            throw new InvalidOperationException("Membership cannot be allowed");
        }

        public override bool CanAcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            return false;
        }

        public override void AcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            throw new InvalidOperationException("Membership cannot be accepted");
        }

        public override bool CanRejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            return false;
        }

        public override void RejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            throw new InvalidOperationException("Membership cannot be rejected");
        }

        public override bool CanCancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            return false;
        }

        public override void CancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            throw new InvalidOperationException("Membership cannot be cancelled again");
        }

        public override AllianceMembershipAction GetAction()
        {
            return AllianceMembershipAction.Cancel;
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
