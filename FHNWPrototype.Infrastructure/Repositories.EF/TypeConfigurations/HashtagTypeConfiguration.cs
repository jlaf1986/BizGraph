using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.Tweets;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class HashtagTypeConfiguration : EntityTypeConfiguration<Hashtag>
    {
        public HashtagTypeConfiguration()
        {
            HasOptional(x => x.AllianceContext).WithMany();
            HasOptional(x => x.OrganizationContext).WithMany();
            HasOptional(x => x.GroupContext).WithMany();

        }
    }
}
