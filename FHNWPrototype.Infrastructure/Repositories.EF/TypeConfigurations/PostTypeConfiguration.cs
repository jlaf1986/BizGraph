using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class PostTypeConfiguration : EntityTypeConfiguration<Post>
    {
        public PostTypeConfiguration()
        {
            HasMany(x => x.Comments).WithOptional(y=> y.Post);

            HasOptional(x => x.Author).WithMany();

            HasMany(x => x.PostLikes).WithOptional(y=>y.Post);
            //HasMany(x => x.Likes).WithOptional();

        }
    }
}
