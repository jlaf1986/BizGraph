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
    public class FriendshipRejectedEventHandler : IDomainEventHandler<FriendshipRejectedEvent>
    {
        public void Handle(FriendshipRejectedEvent domainEvent)
        {
            //create a notification in SignalR
            //send a email

           // UserAccountService userAccountService = new UserAccountService();
            UserAccountService.UpdateFriendshipStatus(domainEvent.FriendshipRejectedBy.Key.ToString(), domainEvent.FriendshipRequestedBy.Key.ToString(), domainEvent.DateTime, FriendshipAction.Reject);


        }
    }
}
