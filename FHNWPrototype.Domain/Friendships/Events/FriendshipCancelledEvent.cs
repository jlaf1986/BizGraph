using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.Friendships.Events
{
    public class FriendshipCancelledEvent  : IDomainEvent
    {
        public UserAccount RelationshipCancelledBy { get; set; }
        public UserAccount RelationshipCancelledWith { get; set; }
        public DateTime DateTime { get; set; }
    }
}
