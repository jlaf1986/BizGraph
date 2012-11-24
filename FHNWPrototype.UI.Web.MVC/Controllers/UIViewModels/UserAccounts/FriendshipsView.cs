using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels.UserAccounts
{
    public class FriendshipsView
    {
        //public String UserKey { get; set; }
        //public String OrganizationKey { get; set; }
        //public String Name { get; set; }
        public List<CompleteProfileView> AcceptedWorkContacts { get; set; }
        public List<CompleteProfileView> AcceptedPartnershipContacts { get; set; }

        public List<CompleteProfileView> RequestorWorkContacts { get; set; }
        public List<CompleteProfileView> RequestorPartnershipContacts { get; set; }

        public List<CompleteProfileView> WorkContactSuggestion { get; set; }
        public List<CompleteProfileView> PartnershipContactSuggestion { get; set; }
        public List<CompleteProfileView> GroupSuggestion { get; set; }
    }

}
