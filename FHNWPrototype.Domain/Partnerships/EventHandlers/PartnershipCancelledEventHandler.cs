using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Partnerships.Events;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.Partnerships.EventHandlers
{
    public class PartnershipCancelledEventHandler : IDomainEventHandler<PartnershipCancelledEvent>
    {
        public void Handle(PartnershipCancelledEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email

        }
    }
}
