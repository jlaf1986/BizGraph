using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Partnerships.Events;
using FHNWPrototype.Domain._Base.Events;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public class PartnershipAcceptedState : PartnershipState 
    {

        private Guid _lastReceiverKey;
        private Guid _lastSenderKey;
        private PartnershipAction _lastAction;

        //public PartnershipAcceptedState(OrganizationAccount sender, IPartnershipRepository repository)
        //{
        //    _sender = sender;
        //    _submitDateTime = DateTime.Now;
        //    _repository = repository;
        //}

        public PartnershipAcceptedState(PartnershipStateInfo info)
        {
            _lastReceiverKey = info.Sender.Key;
            _lastSenderKey = info.Receiver.Key;
            _lastAction = info.Action; 
        }

        public override bool CanRequestPartnershipTo(Guid sender, Guid contactToRequest)
        {
            return false;
        }

        public override void RequestPartnershipTo(Guid sender, Guid contactToRequest)
        {
            throw new NotImplementedException();
        }

        public override bool CanAcceptPartnershipRequestFrom(Guid sender, Guid contactToAccept)
        {
            return false;
        }

        public override void AcceptPartnershipRequestFrom(Guid sender, Guid contactToAccept)
        {
            throw new NotImplementedException();
        }

        public override bool CanRejectPartnershipRequestFrom(Guid sender, Guid contactToReject)
        {
            return false;
        }

        public override void RejectPartnershipRequestFrom(Guid sender, Guid contactToReject)
        {
            throw new NotImplementedException();
        }

        public override bool CanCancelPartnershipWith(Guid sender, Guid contactToCancel)
        {
            return true;
        }

        public override void CancelPartnershipWith(Guid sender, Guid contactToCancel)
        {
            throw new NotImplementedException();
        }

    }
}
