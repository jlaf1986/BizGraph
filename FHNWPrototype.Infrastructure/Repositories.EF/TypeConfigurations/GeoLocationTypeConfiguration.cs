using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Geographics;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class GeoLocationTypeConfiguration : EntityTypeConfiguration<GeoLocation>
    {
        public GeoLocationTypeConfiguration()
        {

        }
    }
}
