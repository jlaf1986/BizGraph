using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public abstract class PartnershipState //: IPartnershipStateBehavior, IPartnershipStateInfo 
    {

        public abstract bool CanRequestPartnershipTo(Guid sender, Guid contactToRequest);

        public abstract void RequestPartnershipTo(Guid sender, Guid contactToRequest);

        public abstract bool CanAcceptPartnershipRequestFrom(Guid sender, Guid contactToAccept);

        public abstract void AcceptPartnershipRequestFrom(Guid sender, Guid contactToAccept);

        public abstract bool CanRejectPartnershipRequestFrom(Guid sender, Guid contactToReject);

        public abstract void RejectPartnershipRequestFrom(Guid sender, Guid contactToReject);

        public abstract bool CanCancelPartnershipWith(Guid sender, Guid contactToCancel);

        public abstract void CancelPartnershipWith(Guid sender, Guid contactToCancel);

    }
}
