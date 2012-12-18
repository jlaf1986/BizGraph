using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Friendships.States
{
    public interface IFriendshipStateInfo
    {
        FriendshipAction GetAction();

        UserAccount GetSender();

        UserAccount GetReceiver();

        DateTime GetActionDateTime();
    }
}
