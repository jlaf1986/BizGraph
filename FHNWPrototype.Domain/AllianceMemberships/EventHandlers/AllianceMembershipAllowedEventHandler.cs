using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.AllianceMemberships.Events;

namespace FHNWPrototype.Domain.AllianceMemberships.EventHandlers
{
    public class AllianceMembershipAllowedEventHandler : IDomainEventHandler<AllianceMembershipAllowedEvent>
    {
        public void Handle(AllianceMembershipAllowedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
