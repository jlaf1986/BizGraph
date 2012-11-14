using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.States
{
    public abstract class AllianceMembershipState :  IAllianceMembershipStateBehavior , IAllianceMembershipStateInfo
    {

        public abstract bool CanRequestAllianceMembershipRequestTo(Alliance allianceToRequest);

        public abstract void RequestAllianceMembershipRequestTo(Alliance allianceToRequest);

        public abstract bool CanOfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer);

        public abstract void OfferAllianceMembershipRequestTo(OrganizationAccount contactToOffer);

        public abstract bool CanAllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow);

        public abstract void AllowAllianceMembershipRequestTo(OrganizationAccount contactToAllow);

        public abstract bool CanAcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept);

        public abstract void AcceptAllianceMembershipRequestFrom(OrganizationAccount contactToAccept);

        public abstract bool CanRejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject);

        public abstract void RejectAllianceMembershipRequestFrom(OrganizationAccount contactToReject);

        public abstract bool CanCancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel);

        public abstract void CancelAllianceMembershipRequestOf(OrganizationAccount contactToCancel);

        public abstract AllianceMembershipAction GetAction();

        public abstract OrganizationAccount GetRequestorOrganization();

        public abstract Alliance GetRequestedAlliance();

        public abstract DateTime GetActionDateTime();

    }
}
