using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Groups;

namespace FHNWPrototype.Domain.GroupMemberships.Events
{
    public class GroupMembershipRequestedEvent : IDomainEvent
    {
        public UserAccount MembershipRequestedBy { get; set; }
        public Group MembershipRequestedTo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
