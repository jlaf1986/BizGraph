using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public interface IPartnershipStateInfo
    {
        PartnershipAction GetAction();

        OrganizationAccount GetSender();

        OrganizationAccount GetReceiver();

        DateTime GetActionDateTime();
    }
}
