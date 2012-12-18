using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Publishing.Files;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class FolderTypeConfiguration : EntityTypeConfiguration<Folder>
    {
        public FolderTypeConfiguration()
        {
            HasMany(x => x.SubFolders).WithOptional(y => y.ParentFolder).HasForeignKey(z=>z.ParentFolderID);

            HasMany(x => x.Documents).WithOptional(y => y.ParentFolder);
        }
    }
}
