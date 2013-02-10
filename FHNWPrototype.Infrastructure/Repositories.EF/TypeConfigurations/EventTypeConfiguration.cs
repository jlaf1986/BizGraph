using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class EventTypeConfiguration : EntityTypeConfiguration<Event>
    {
        public EventTypeConfiguration()
        {
            HasOptional(x => x.TriggeredBy).WithMany();
            
        }
    }
}
