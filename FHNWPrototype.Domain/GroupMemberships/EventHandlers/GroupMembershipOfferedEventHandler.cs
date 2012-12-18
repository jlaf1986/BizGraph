using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.GroupMemberships.Events;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.GroupMemberships.EventHandlers
{
    public class GroupMembershipOfferedEventHandler : IDomainEventHandler<GroupMembershipOfferedEvent>
    {
        public void Handle(GroupMembershipOfferedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
