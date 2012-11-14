using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class SystemAuthenticationTokenViewModel
    {
        public Boolean IsAuthenticated { get; set; }

        public CompleteProfileViewModel MyProfile { get; set; } 
        public String Email { get; set; }

        public DateTime LastSuccesfulLogin { get; set; }
        
    }
}
