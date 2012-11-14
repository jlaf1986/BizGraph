using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Friendships.States
{
    public abstract class FriendshipState
    {
        public abstract bool CanRequestFriendshipTo(Guid sender, Guid contactToRequest);

        public abstract void RequestFriendshipTo(Guid sender, Guid contactToRequest);

        public abstract bool CanAcceptFriendshipRequestFrom(Guid sender, Guid contactToAccept);

        public abstract void AcceptFriendshipRequestFrom(Guid sender, Guid contactToAccept);

        public abstract bool CanRejectFriendshipRequestFrom(Guid sender, Guid contactToReject);

        public abstract void RejectFriendshipRequestFrom(Guid sender, Guid contactToReject);

        public abstract bool CanCancelFriendshipWith(Guid sender, Guid contactToCancel);

        public abstract void CancelFriendshipWith(Guid sender, Guid contactToCancel);
    }
}
