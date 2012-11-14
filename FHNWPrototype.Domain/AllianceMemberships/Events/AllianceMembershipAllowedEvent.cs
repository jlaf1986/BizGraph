using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.AllianceMemberships.Events
{
    public class AllianceMembershipAllowedEvent : IDomainEvent
    {
        public Alliance MembershipAllowedBy { get; set; }
        public OrganizationAccount MembershipAllowedTo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
