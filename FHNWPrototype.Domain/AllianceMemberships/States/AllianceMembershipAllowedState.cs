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
    public class AllianceMembershipAllowedState : AllianceMembershipState 
    {

        private OrganizationAccount _requestorOrganization;
        private Alliance _requestedAlliance;
        private DateTime _submitDateTime = DateTime.Now;
        private IAllianceMembershipRepository _repository;

        public AllianceMembershipAllowedState(OrganizationAccount thisPerson, IAllianceMembershipRepository repository)
        {
            _requestorOrganization = thisPerson;
            _submitDateTime = DateTime.Now;
            _repository = repository;
        }

        public override bool CanRequestAllianceMembershipRequestTo(Alliance allianceToRequest)
        {
            return false;
        }

        public override void RequestAllianceMembershipRequestTo(Alliance  allianceToRequest)
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
            return false;
        }

        public override void AllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow)
        {
            throw new InvalidOperationException("Membership cannot be allowed again");
        }

        public override bool CanAcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept)
        {
            //check conditions
           // _requestedAlliance = contactToAccept;
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
            return true;
        }

        public override void CancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel)
        {
            if (CanCancelAllianceMembershipRequestOf(contactToCancel))
            {
                DomainEvents.Raise(new AllianceMembershipCancelledEvent { MembershipCancelledBy = _requestedAlliance, DateTime = DateTime.Now, MembershipCancelledTo = contactToCancel });
            }
            else
            {
                throw new InvalidOperationException("Membership cannot be cancelled");
            }
        }

        public override AllianceMembershipAction GetAction()
        {
            return AllianceMembershipAction.Allow;
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
