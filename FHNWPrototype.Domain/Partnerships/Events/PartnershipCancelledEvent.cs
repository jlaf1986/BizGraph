using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.Events
{
    public class PartnershipCancelledEvent : IDomainEvent
    {
        public OrganizationAccount PartnershipCancelledBy { get; set; }
        public OrganizationAccount PartnershipCancelledWith { get; set; }
        public DateTime DateTime { get; set; }
    }
}
