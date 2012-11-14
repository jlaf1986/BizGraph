using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.AllianceMemberships.Events;

namespace FHNWPrototype.Domain.AllianceMemberships.EventHandlers
{
    public class AllianceMembershipCancelledEventHandler : IDomainEventHandler<AllianceMembershipCancelledEvent>
    {
        public void Handle(AllianceMembershipCancelledEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
