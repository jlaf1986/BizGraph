using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.Files;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class LibraryTypeConfiguration : EntityTypeConfiguration<Library>
    {
        public LibraryTypeConfiguration()
        {
            //HasOptional(x => x.RootFolder).WithOptionalDependent();
            HasMany(x => x.Folders).WithOptional(y => y.Library).HasForeignKey(z => z.LibraryID);
            HasOptional(x => x.Owner).WithOptionalDependent(y => y.DocumentLibrary);
        }
    }
}
