using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Partnerships.Events;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.Partnerships.EventHandlers
{
    public class PartnershipRejectedEventHandler : IDomainEventHandler<PartnershipRejectedEvent>
    {
        public void Handle(PartnershipRejectedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email

        }
    }
}
