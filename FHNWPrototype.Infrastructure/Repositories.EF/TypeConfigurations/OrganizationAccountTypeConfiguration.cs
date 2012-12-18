using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class OrganizationAccountTypeConfiguration : EntityTypeConfiguration<OrganizationAccount>
    {
        public OrganizationAccountTypeConfiguration()
        {


            HasMany(x => x.Employees).WithOptional(y => y.OrganizationAccount).Map(m => m.MapKey("OrganizationAccountID"));


            HasMany(x => x.PartnershipsReceived).WithOptional(y => y.Receiver).HasForeignKey(z => z.ReceiverID);
            HasMany(x => x.PartnershipsRequested).WithOptional(y => y.Sender).HasForeignKey(z => z.SenderID);

            HasMany(x => x.AllianceMemberships).WithOptional(y => y.OrganizationRequestor).HasForeignKey(z => z.OrganizationRequestorID);

        }
    }
}
