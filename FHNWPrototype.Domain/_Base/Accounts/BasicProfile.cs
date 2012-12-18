using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain._Base.Accounts
{
    public class BasicProfile
    {
        public virtual int ID { get; set; }
        public virtual Guid ReferenceKey { get; set; }
        public virtual AccountType ReferenceType { get; set; }
    }
}
