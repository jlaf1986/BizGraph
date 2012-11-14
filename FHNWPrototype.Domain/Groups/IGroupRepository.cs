using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.GroupMemberships.States;

namespace FHNWPrototype.Domain.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<GroupMembershipStateInfo> GetAllGroupMembershipsByGroupKey(Guid key);   

    }
}
