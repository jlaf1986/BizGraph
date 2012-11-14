using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.AllianceMemberships.States
{
    public interface IAllianceMembershipStateBehavior
    {

        Boolean CanRequestAllianceMembershipRequestTo(Alliance allianceToRequest);
        void RequestAllianceMembershipRequestTo(Alliance allianceToRequest);

        Boolean CanOfferAllianceMembershipRequestTo(OrganizationAccount organizationToOffer);
        void OfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer);

        Boolean CanAllowAllianceMembershipRequestTo(OrganizationAccount orgnizationToAllow);
        void AllowAllianceMembershipRequestTo(OrganizationAccount orgnizationToAllow);

        Boolean CanAcceptAllianceMembershipRequestFrom(OrganizationAccount organizationToAccept);
        void AcceptAllianceMembershipRequestFrom(OrganizationAccount organizationToAccept);

        Boolean CanRejectAllianceMembershipRequestFrom(OrganizationAccount organizationToReject);
        void RejectAllianceMembershipRequestFrom(OrganizationAccount organizationToReject);

        Boolean CanCancelAllianceMembershipRequestOf(OrganizationAccount organizationToCancel);
        void CancelAllianceMembershipRequestOf(OrganizationAccount organizationToCancel);

    }
}
