using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Publishing.Likes;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class LikeTypeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeTypeConfiguration()
        {
            HasOptional(x => x.Author).WithMany();
            //HasOptional(x=>x.Holder)
           
        }
    }
}
