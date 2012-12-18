using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.Likes;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class PostLikeTypeConfiguration : EntityTypeConfiguration<PostLike>
    {
        public PostLikeTypeConfiguration()
        {

        }
    }
}
