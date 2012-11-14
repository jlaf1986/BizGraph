using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.States
{
    public interface IAllianceMembershipStateInfo
    {

        AllianceMembershipAction GetAction();

        OrganizationAccount GetRequestorOrganization();

        Alliance GetRequestedAlliance();

        DateTime GetActionDateTime();

    }
}
