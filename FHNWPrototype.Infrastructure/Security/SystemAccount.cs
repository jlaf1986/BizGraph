using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Security
{
    public class SystemAccount
    {
        public virtual int ID { get; set; }

        //public virtual Guid Key { get; set; }

        public virtual String Email { get; set; }

        public virtual String Password { get; set; }

        //public Boolean IsCorporateAccount { get; set; }

        public virtual BasicProfile  Holder { get; set; }      

        public virtual Boolean IsConfirmed { get; set; }

        //public Boolean IsCurrentlyConnected { get; set; } 
 

        //public Boolean IsDisabled { get; set; }

        //public DateTime CreationDateTime { get; set; }

        //public DateTime LastSuccesfulLogIn { get; set; }

        //public DateTime LastSuccesfulLogOut { get; set; }
    }
}
