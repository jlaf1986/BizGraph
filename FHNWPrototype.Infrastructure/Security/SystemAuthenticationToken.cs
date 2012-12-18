using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Security
{
    public class SystemAuthenticationToken
    {
        public Boolean IsAuthenticated { get; set; }
        public CompleteProfile MyProfile { get; set; }
        public String Email { get; set; }       
        public DateTime LastSuccesfulLogin { get; set; }
    }
}
