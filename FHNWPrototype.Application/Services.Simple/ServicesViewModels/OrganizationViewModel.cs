using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class OrganizationViewModel
    {
        //public String Key { get; set; }
        //public String Name { get; set; }
        //public String Description { get; set; }
        public CompleteProfileViewModel Profile { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public List<String> Wall { get; set; }
    }
}