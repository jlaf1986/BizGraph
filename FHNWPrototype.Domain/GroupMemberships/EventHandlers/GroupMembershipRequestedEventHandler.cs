using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.GroupMemberships.Events;

namespace FHNWPrototype.Domain.GroupMemberships.EventHandlers
{
    public class GroupMembershipRequestedEventHandler : IDomainEventHandler<GroupMembershipRequestedEvent>
    {
        public void Handle(GroupMembershipRequestedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
