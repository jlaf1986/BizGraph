using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.GroupMemberships.States;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class GroupMembershipTypeConfiguration : EntityTypeConfiguration<GroupMembershipStateInfo>
    {
        public GroupMembershipTypeConfiguration()
        {
        }
    }
}
