using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public static class PartnershipStateFactory
    {
        public static PartnershipState GetPartnershipStateBasedOnInfo(PartnershipStateInfo info)
        {
            switch (info.Action)
            {
                case PartnershipAction.Accept:
                    return new PartnershipAcceptedState(info);
                case PartnershipAction.Cancel:
                    return new PartnershipCancelledState(info);
                case PartnershipAction.Reject:
                    return new PartnershipRejectedState(info);
                case PartnershipAction.Request:
                    return new PartnershipRequestedState(info);
                default:
                    return new PartnershipNewState(info);
            }
        }
    }
}
