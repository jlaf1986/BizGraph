using System.Data;
using System.Data.Entity;
using FHNWPrototype.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class UserAccountTypeConfiguration : EntityTypeConfiguration<UserAccount>
    {

        public UserAccountTypeConfiguration()
        {
            //working
            HasMany(x => x.FriendshipsReceived).WithOptional(y => y.Receiver).HasForeignKey(z => z.ReceiverID);
            HasMany(x => x.FriendshipsRequested).WithOptional(y => y.Sender).HasForeignKey(z => z.SenderID);

            //HasMany(x => x.PersonalAcquaintanceships).WithOptional();
            //HasMany(x => x.PersonalAcquaintanceships).WithMany();

            HasOptional(x => x.OrganizationAccount).WithOptionalDependent();

            HasMany(x => x.GroupMemberships).WithOptional(y => y.RequestorAccount).HasForeignKey(z => z.RequestorAccountID);

            //HasMany(x => x.PersonalAcquaintanceships).WithOptional(y => y.Receiver).HasForeignKey(z=> z.
            //HasMany(x => x.PersonalAcquaintanceships).WithOptional(y => y.Sender).WillCascadeOnDelete();

            //HasMany(x => x.PersonalAcquaintanceships).WithOptional(y => y.Receiver);
            
      

            //HasMany(x => x.PersonalAcquaintanceships)
            //    .WithOptional(y => y.Sender)
            //    .HasForeignKey(z=>z.

            //HasMany(x => x.PersonalAcquaintanceships)
            //  .WithOptional(y => y.Receiver);

            //Property(d => d.).
            //IsRequired();


            //Property(d => d.Organization).
            //HasDatabaseGeneratedOption( DatabaseGeneratedOption.None );


            //HasMany(d => d.).
            //WithRequired(c => c.Department).
            //HasForeignKey(c => c.DepartmentID).
            //WillCascadeOnDelete();

            


            //Ignore(d => d.Organization);
        }

    }
}
