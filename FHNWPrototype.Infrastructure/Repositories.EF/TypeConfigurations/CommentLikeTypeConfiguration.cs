using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.Likes;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    class CommentLikeTypeConfiguration : EntityTypeConfiguration<CommentLike>
    {
        public CommentLikeTypeConfiguration()
        {

        }
    }
}
