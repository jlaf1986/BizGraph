using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Partnerships.Events;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Partnerships.EventHandlers
{
    public class PartnershipAcceptedEventHandler : IDomainEventHandler<PartnershipAcceptedEvent>
    {

        public void Handle(PartnershipAcceptedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email
            
        }
    }
}
