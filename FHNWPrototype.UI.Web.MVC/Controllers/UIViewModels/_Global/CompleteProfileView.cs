using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels._Global
{
    public class CompleteProfileView
    {
        public BasicProfileView BasicProfile { get; set; }
        public string FullName { get; set; }
        public bool IsConnected { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
