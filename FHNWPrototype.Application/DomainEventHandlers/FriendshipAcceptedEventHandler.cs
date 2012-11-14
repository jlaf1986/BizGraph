using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Friendships.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHNWPrototype.Domain.Friendships.States;

namespace FHNWPrototype.Application.DomainEventHandlers
{
 public class FriendshipAcceptedEventHandler : IDomainEventHandler<FriendshipAcceptedEvent>
    {

        public void Handle(FriendshipAcceptedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email
            
           // UserAccountService userAccountService = new UserAccountService();
            UserAccountService.UpdateFriendshipStatus(domainEvent.FriendshipRequestedBy.Key.ToString(), domainEvent.FriendshipAcceptedBy.Key.ToString(), domainEvent.DateTime, FriendshipAction.Accept);

        }
    }
}
