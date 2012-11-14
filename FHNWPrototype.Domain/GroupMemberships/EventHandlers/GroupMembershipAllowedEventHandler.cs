using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.GroupMemberships.Events;

namespace FHNWPrototype.Domain.GroupMemberships.EventHandlers
{
    public class GroupMembershipAllowedEventHandler : IDomainEventHandler<GroupMembershipAllowedEvent>
    {
        public void Handle(GroupMembershipAllowedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
