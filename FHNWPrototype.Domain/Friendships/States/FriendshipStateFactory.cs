using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Friendships.States
{
    public static class FriendshipStateFactory
    {
        public static FriendshipState GetFriendshipStateBasedOnInfo(FriendshipStateInfo info)
        {
            switch (info.Action)
            {
                case FriendshipAction.Accept:
                    return new FriendshipAcceptedState(info);
                case FriendshipAction.Cancel:
                    return new FriendshipCancelledState(info);
                case FriendshipAction.Reject:
                    return new FriendshipRejectedState(info);
                case FriendshipAction.Request:
                    return new FriendshipRequestedState(info);
                default:
                    return new FriendshipNewState(info);
            }
        }
    }
}
