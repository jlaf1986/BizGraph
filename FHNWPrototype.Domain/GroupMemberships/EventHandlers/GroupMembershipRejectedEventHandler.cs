﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.GroupMemberships.Events;

namespace FHNWPrototype.Domain.GroupMemberships.EventHandlers
{
    public class GroupMembershipRejectedEventHandler : IDomainEventHandler<GroupMembershipRejectedEvent>
    {
        public void Handle(GroupMembershipRejectedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
