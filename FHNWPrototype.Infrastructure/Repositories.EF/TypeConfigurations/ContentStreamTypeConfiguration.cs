using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.ContentStreams;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class ContentStreamTypeConfiguration : EntityTypeConfiguration<ContentStream>
    {
        public ContentStreamTypeConfiguration()
        {
            HasMany(x => x.Posts).WithOptional(y => y.Wall);
            HasMany(x => x.Tweets).WithOptional(y => y.Wall);
            HasMany(x => x.Retweets).WithOptional(y => y.Wall);
            //HasOptional(x => x.Workspace).WithOptionalDependent(y=>y.Wall);
            //HasOptional(x => x.Owner).WithOptionalDependent(y=>y.Wall);
        }
    }
}
