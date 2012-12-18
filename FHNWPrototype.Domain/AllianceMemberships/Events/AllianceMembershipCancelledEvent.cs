using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.Events
{
    public class AllianceMembershipCancelledEvent : IDomainEvent
    {
        public Alliance MembershipCancelledBy { get; set; }
        public OrganizationAccount MembershipCancelledTo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
