using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class SuscriptionTypeConfiguration : EntityTypeConfiguration<Suscription>
    {
        public SuscriptionTypeConfiguration()
        {
            HasOptional(x => x.Suscriber).WithMany();
        }
    }
}
