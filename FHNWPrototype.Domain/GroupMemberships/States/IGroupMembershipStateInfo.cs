using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Groups;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public interface IGroupMembershipStateInfo
    {
        GroupMembershipAction GetAction();

        UserAccount GetRequestor();

        Group GetRequestedGroup();

        DateTime GetActionDateTime();
    }
}
