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
    public class AllianceMembershipOfferedState : AllianceMembershipState 
    {

        private OrganizationAccount _requestorOrganization;
        private Alliance _requestedAlliance;
        private DateTime _submitDateTime = DateTime.Now;
        private IAllianceMembershipRepository _repository;

        public AllianceMembershipOfferedState(OrganizationAccount thisPerson, IAllianceMembershipRepository repository)
        {
            _requestorOrganization = thisPerson;
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
            throw new InvalidOperationException("Membership cannot be offered again");
        }

        public override bool CanAllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
           // _requestedAlliance = contactToAllow;
            return true;
        }

        public override void AllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            if (CanAllowAllianceMembershipRequestTo(contactToAllow))
            {
                DomainEvents.Raise(new AllianceMembershipAllowedEvent { MembershipAllowedBy = _requestedAlliance, DateTime = DateTime.Now, MembershipAllowedTo = contactToAllow });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be allowed");
            }
        }

        public override bool CanAcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            //check conditions
            return true;
        }

        public override void AcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            if (CanAcceptAllianceMembershipRequestFrom(contactToAccept))
            {
                DomainEvents.Raise(new AllianceMembershipAcceptedEvent { MembershipAcceptedBy = _requestedAlliance, DateTime = DateTime.Now, MembershipRequestedBy = contactToAccept });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be accepted");
            }
        }

        public override bool CanRejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            return true;
        }

        public override void RejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject)
        {
            if (CanRejectAllianceMembershipRequestFrom(contactToReject))
            {
                DomainEvents.Raise(new AllianceMembershipRejectedEvent { MembershipRejectedBy = _requestedAlliance, DateTime = DateTime.Now, MembershipRequestedBy = contactToReject });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be rejected");
            }
        }

        public override bool CanCancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            return false;
        }

        public override void CancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            throw new InvalidOperationException("Membership cannot be cancelled before being accepted");
        }

        public override AllianceMembershipAction GetAction()
        {
            return AllianceMembershipAction.Offer;
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
