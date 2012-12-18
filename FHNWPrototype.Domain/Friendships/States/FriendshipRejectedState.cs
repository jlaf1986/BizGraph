using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Friendships.States
{
    public class FriendshipRejectedState : FriendshipState 
    {
        private Guid _lastReceiverKey;
        private Guid _lastSenderKey;
        private FriendshipAction _lastAction;
       

        public FriendshipRejectedState(FriendshipStateInfo info)
        {
            _lastReceiverKey = info.Sender.Key;
            _lastSenderKey = info.Receiver.Key;
            _lastAction = info.Action; 
        }


        public override bool CanRequestFriendshipTo(Guid sender, Guid contactToRequest)
        {
            return true;
        }

        public override void RequestFriendshipTo(Guid sender, Guid contactToRequest)
        {
            throw new NotImplementedException();
        }

        public override bool CanAcceptFriendshipRequestFrom(Guid sender, Guid contactToAccept)
        {
            return false;
        }

        public override void AcceptFriendshipRequestFrom(Guid sender, Guid contactToAccept)
        {
            throw new NotImplementedException();
        }

        public override bool CanRejectFriendshipRequestFrom(Guid sender, Guid contactToReject)
        {
            return false;
        }

        public override void RejectFriendshipRequestFrom(Guid sender, Guid contactToReject)
        {
            throw new NotImplementedException();
        }

        public override bool CanCancelFriendshipWith(Guid sender, Guid contactToCancel)
        {
            return false;
        }

        public override void CancelFriendshipWith(Guid sender, Guid contactToCancel)
        {
            throw new NotImplementedException();
        }
    }
}
