using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.AllianceMemberships.States;

namespace FHNWPrototype.Domain.Alliances
{
    public interface IAllianceRepository : IRepository<Alliance>
    {
        IEnumerable<AllianceMembershipStateInfo> GetAllAllianceMembershipsByAllianceKey(Guid key);
    }
}
