using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Friendships.States
{
    public interface IFriendshipStateBehavior
    {
        Boolean CanRequestFriendshipTo(UserAccount contactToRequest);
        void RequestFriendshipTo(UserAccount contactToRequest);

        Boolean CanAcceptFriendshipRequestFrom(UserAccount contactToAccept);
        void AcceptFriendshipRequestFrom(UserAccount contactToAccept);

        Boolean CanRejectFriendshipRequestFrom(UserAccount contactToReject);
        void RejectFriendshipRequestFrom(UserAccount contactToReject);

        Boolean CanCancelFriendshipWith(UserAccount contactToCancel);
        void CancelFriendshipWith(UserAccount contactToCancel);
            
    }
}
