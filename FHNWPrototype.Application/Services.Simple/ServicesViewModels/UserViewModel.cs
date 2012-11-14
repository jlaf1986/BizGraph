using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class UserViewModel
    {
        public string Key { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Byte[] ProfilePicture { get; set; }

        public Dictionary<String,String> UserAccounts { get; set; }
    }
}
