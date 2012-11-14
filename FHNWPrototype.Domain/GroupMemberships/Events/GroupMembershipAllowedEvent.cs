using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.Users;


namespace FHNWPrototype.Domain.GroupMemberships.Events
{
    public class GroupMembershipAllowedEvent : IDomainEvent
    {
        public Group MembershipAllowedBy { get; set; }
        public UserAccount MembershipAllowedTo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
