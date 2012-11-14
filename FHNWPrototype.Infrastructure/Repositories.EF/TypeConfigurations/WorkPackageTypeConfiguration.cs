using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Projects;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class WorkPackageTypeConfiguration : EntityTypeConfiguration<WorkPackage>
    {
        public WorkPackageTypeConfiguration()
        {
            HasMany(x => x.ChildWorkPackages).WithOptional(y => y.ParentWorkPackage).HasForeignKey(z => z.ParentWorkPackageID);
            HasOptional(x => x.Owner).WithMany();
        }
    }
}
