using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using FHNWPrototype.Domain.Friendships.States;

namespace FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations
{
    public class FriendshipTypeConfiguration : EntityTypeConfiguration<FriendshipStateInfo>
    {
        public FriendshipTypeConfiguration()
        {
            //HasMany(x => x.Receiver )
            //   .WithMany(e => e.Receiver)
            //   .Map(m =>
            //   {
            //       m.ToTable();
            //       m.MapLeftKey();
            //       m.MapRightKey();
            //   });

            //HasOptional(x => x.Receiver).WithOptionalDependent();
            //HasOptional(x => x.Sender).WithOptionalDependent();

            //HasOptional(x => x.Sender).WithMany(y => y.FriendshipsRequested).HasForeignKey(i => i.SenderID);
            //HasOptional(x => x.Receiver).WithMany(y => y.FriendshipsReceived).HasForeignKey(i=> i.ReceiverID);
        
        }
    }
}
