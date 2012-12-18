using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Partnerships.Events;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.Partnerships.EventHandlers
{
    public class PartnershipRequestedEventHandler : IDomainEventHandler<PartnershipRequestedEvent>
    {
        public void Handle(PartnershipRequestedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email

        }
    }
}
