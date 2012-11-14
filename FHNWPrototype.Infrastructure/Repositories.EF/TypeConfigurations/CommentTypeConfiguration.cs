using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class CommentTypeConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentTypeConfiguration()
        {
            HasMany(x => x.CommentLikes).WithOptional(y=>y.Comment) ;

        }
    }
}
