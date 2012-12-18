using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class UserAccountViewModel
    {
       
        //public String UserAccountKey { get; set; }
        //public String UserKey { get; set; }
        //public String UserName { get; set; }
        public CompleteProfileViewModel Profile { get; set; }
        public String Email { get; set; }
        //public KeyValuePair<String, String> OrganizationAccount { get; set;}
        //public KeyValuePair<String,String> Organization { get; set; }
        public List<CompleteProfileViewModel> WorkContacts { get; set; }
        public List<CompleteProfileViewModel> PartnershipContacts { get; set; }
        public List<CompleteProfileViewModel> Groups { get; set; }
        public ContentStreamViewModel Wall { get; set; }
    }
}