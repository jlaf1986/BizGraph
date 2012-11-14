using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class OrganizationAccountViewModel
    {
        //public String Key { get; set; }
        //public String Name { get; set; }
        //public String Description { get; set; }
        public CompleteProfileViewModel Profile { get; set; }
        public String Email { get; set; }
        public CompleteProfileViewModel  Organization { get; set; }
       // public List<CompleteProfileViewModel> SisterDivisions { get; set; }
        public List<CompleteProfileViewModel> Employees { get; set; }
        public List<CompleteProfileViewModel> Partners { get; set; }
        public List<CompleteProfileViewModel> Alliances { get; set; }
        public GeoLocationViewModel Location { get; set;}
        public ContentStreamViewModel Wall { get; set; }
    }
}