using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Publishing.Files;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class DocumentTypeConfiguration : EntityTypeConfiguration<Document>
    {

        public DocumentTypeConfiguration()
        {
        }

    }
}
