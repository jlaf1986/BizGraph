using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels._Global
{
    public class BasicProfileView
    {
        public String ReferenceKey { get; set; }
        public AccountType AccountType { get; set; }
    }
}