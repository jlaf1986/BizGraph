using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class AllianceTypeConfiguration : EntityTypeConfiguration<Alliance>
    {
        public AllianceTypeConfiguration()
        {

            HasMany(x => x.AllianceMemberships).WithOptional(y => y.AllianceRequested).HasForeignKey(z => z.AllianceRequestedID);

        }
    }
}
