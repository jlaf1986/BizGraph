﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Events;

namespace FHNWPrototype.Domain.Friendships.Events
{
    public class FriendshipAcceptedEvent : IDomainEvent
    {
        public UserAccount FriendshipAcceptedBy { get; set; }
        public UserAccount FriendshipRequestedBy { get; set; }
        public DateTime DateTime { get; set; }
    }
}
