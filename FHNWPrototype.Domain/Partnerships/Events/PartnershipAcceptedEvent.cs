using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.Events
{
    public class PartnershipAcceptedEvent : IDomainEvent
    {
        public OrganizationAccount PartnershipAcceptedBy { get; set; }
        public OrganizationAccount PartnershipRequestedBy { get; set; }
        public DateTime DateTime { get; set; }
    }
}
