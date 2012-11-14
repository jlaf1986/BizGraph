using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class BasicProfileViewModel
    {

        public String ReferenceKey { get; set; }
        public AccountType AccountType { get; set; }

    }
}
