using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.OrganizationAccounts
{
    public class PartnershipsView
    {
        //public String OrganizationAccountKey { get; set; }
        //public String OrganizationKey { get; set; }
        //public String Name { get; set; }
        public List<CompleteProfileView> AcceptedSisterDivisions { get; set; }
        public List<CompleteProfileView> AcceptedPartners { get; set; }

        public List<CompleteProfileView> RequestorSisterDivisions { get; set; }
        public List<CompleteProfileView> RequestorPartners { get; set; }

        public List<CompleteProfileView> SisterDivisionSuggestions { get; set; }
        public List<CompleteProfileView> PartnerSuggestions { get; set; }
        public List<CompleteProfileView> AllianceSuggestions { get; set; }
    }

 
}
