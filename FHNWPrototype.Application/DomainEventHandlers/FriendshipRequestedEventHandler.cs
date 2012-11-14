using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Friendships.Events;
using FHNWPrototype.Domain.Friendships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.DomainEventHandlers
{
    public class FriendshipRequestedEventHandler : IDomainEventHandler<FriendshipRequestedEvent>
    {
        public void Handle(FriendshipRequestedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email
           // UserAccountService userAccountService = new UserAccountService();
            UserAccountService.UpdateFriendshipStatus(domainEvent.FriendshipRequestedBy.Key.ToString(), domainEvent.FriendshipRequestedTo.Key.ToString(), domainEvent.DateTime, FriendshipAction.Accept);

        }
    }
}
