using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class OrganizationTypeConfiguration :  EntityTypeConfiguration<Organization>
    {
        public OrganizationTypeConfiguration()
        {
            //HasMany(d => d.Employees).
            //WithRequired(y => y.Organization).
            //Map(m => m.MapKey("AccountId"));
            //HasOptional(x => x.Administrator).WithOptionalDependent();

        }
    }
}
