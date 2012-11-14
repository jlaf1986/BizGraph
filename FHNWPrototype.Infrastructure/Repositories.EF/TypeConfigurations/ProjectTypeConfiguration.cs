using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Projects;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class ProjectTypeConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectTypeConfiguration()
        {
            HasOptional(x => x.WorkBreakdownStructure).WithOptionalPrincipal();
            HasOptional(x => x.Coordinator).WithOptionalDependent();
        }
    }
}
