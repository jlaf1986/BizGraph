using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.AllianceMemberships.Events;

namespace FHNWPrototype.Domain.AllianceMemberships.EventHandlers
{
    public class AllianceMembershipRejectedEventHandler : IDomainEventHandler<AllianceMembershipRejectedEvent>
    {
        public void Handle(AllianceMembershipRejectedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
