using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public interface IPartnershipStateBehavior
    {
        Boolean CanRequestPartnershipTo(OrganizationAccount contactToRequest);
        void RequestPartnershipTo(OrganizationAccount contactToRequest);

        Boolean CanAcceptPartnershipRequestFrom(OrganizationAccount contactToAccept);
        void AcceptPartnershipRequestFrom(OrganizationAccount contactToAccept);

        Boolean CanRejectPartnershipRequestFrom(OrganizationAccount contactToReject);
        void RejectPartnershipRequestFrom(OrganizationAccount contactToReject);

        Boolean CanCancelPartnershipWith(OrganizationAccount contactToCancel);
        void CancelPartnershipWith(OrganizationAccount contactToCancel);
            
    }
}
