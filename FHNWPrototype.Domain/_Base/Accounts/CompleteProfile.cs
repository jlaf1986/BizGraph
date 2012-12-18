using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain._Base.Accounts
{
    public class CompleteProfile
    {
        public BasicProfile BasicProfile { get; set; }
        public string FullName { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
