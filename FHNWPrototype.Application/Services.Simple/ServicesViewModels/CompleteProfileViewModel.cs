using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class CompleteProfileViewModel
    {

        public BasicProfileViewModel BasicProfile { get; set; }
        public string FullName { get; set; }
        //public bool IsConnected { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }

    }
}
