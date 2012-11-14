using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Groups;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class GroupTypeConfiguration : EntityTypeConfiguration<Group>
    {

        public GroupTypeConfiguration()
        {
            //HasOptional(x => x.Administrator).WithOptionalDependent();

            //HasRequired(x => x.Administrator).WithRequiredDependent();
            HasMany(x => x.GroupMemberships).WithOptional(y => y.RequestedGroup).HasForeignKey(z => z.RequestedGroupID);
        }

    }
}
