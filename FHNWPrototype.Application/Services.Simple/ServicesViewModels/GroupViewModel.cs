using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class GroupViewModel
    {
        //public String Key { get; set; }
        //public String Name { get; set; }
        //public String Description { get; set; }
        public CompleteProfileViewModel Profile { get; set; }
        public List<CompleteProfileViewModel> Members { get; set; }
        public List<String> Documents { get; set; }
        public ContentStreamViewModel Wall { get; set; }
    }
}