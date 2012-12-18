using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace FHNWPrototype.Application.Controllers.UIViewModels.Users
{
    public class UserView
    {

        public String Key { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Dictionary<String,String> Accounts { get; set; }
       // public System.Drawing.Image ProfilePic { get; set; } 
        //public List<String> Groups { get; set; }
        //public List<String> PartnershipContacts { get; set; }
        //public List<String> WorkContacts { get; set; }
    }
}
