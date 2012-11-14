using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace FHNWPrototype.Application.Controllers.UIViewModels.Organizations
{
    public class OrganizationView
    {
        public String Key { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Latitude { get; set;}
        public double Longitude { get; set; }
        public Dictionary<string, string> PartnersCoordinates { get; set; }
        public int Counter { get; set; }
        public List<String> Wall { get; set; }
    }
}
