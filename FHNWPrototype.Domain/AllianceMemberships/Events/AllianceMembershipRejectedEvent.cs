using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.Events
{
    public class AllianceMembershipRejectedEvent : IDomainEvent
    {

        public Alliance MembershipRejectedBy { get; set; }
        public OrganizationAccount MembershipRequestedBy { get; set; }
        public DateTime DateTime { get; set; }

    }
}
