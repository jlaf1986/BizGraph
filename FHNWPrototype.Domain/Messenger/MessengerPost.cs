using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain._Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Messenger
{
    public class MessengerPost : EntityBase
    {
        public virtual Guid ChatRoom { get; set; }
        public virtual String Text { get; set; }
        public virtual DateTime PublishDateTime { get; set; }
        public virtual BasicProfile Author { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
