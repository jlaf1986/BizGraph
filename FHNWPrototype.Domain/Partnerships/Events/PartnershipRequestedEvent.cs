using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.Events
{
    public class PartnershipRequestedEvent : IDomainEvent
    {
        public OrganizationAccount PartnershipRequestedBy { get; set; }
        public OrganizationAccount PartnershipRequestedTo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
