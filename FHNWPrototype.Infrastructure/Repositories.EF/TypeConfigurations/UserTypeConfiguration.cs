using System.Data.Entity;
using FHNWPrototype.Domain.Users;
using System.Data.Entity.ModelConfiguration;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {

            HasOptional(x => x.GeoLocation).WithOptionalDependent();

            //Property(d => d.).
            //IsRequired().
            //HasMaxLength(50);


            //Property(d => d.ID ).
            //HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            //HasMany(d => d.Key).
            //WithRequired(c => c.Department).
            //HasForeignKey(c => c.DepartmentID).
            //WillCascadeOnDelete();

            HasMany(x => x.UserAccounts) // User has many acounts
            .WithOptional(y => y.User) // UserAccount has required user
            .Map(m => m.MapKey("UserID")); //Map foreign key in db to user id

            //Ignore(d => d.PersonalEmail);
        }
    }
}
