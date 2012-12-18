using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.Tweets;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class TweetTypeConfiguration : EntityTypeConfiguration<Tweet>
    {
        public TweetTypeConfiguration() 
        {
            HasOptional(x => x.Author).WithMany();
          //  HasOptional(x => x.Hashtag).WithMany();

            HasMany(x => x.Retweets).WithOptional();

        }
    }
}
