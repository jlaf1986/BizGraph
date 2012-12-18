using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.OrganizationAccounts
{
    public class OrganizationAccountsView
    {
        public Dictionary<String, String> OrganizationAccounts { get; set; }

        public String AccountKey { get; set; }
        public KeyValuePair<String,String> Organization { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        //Properties related with viewer of the account
        public Boolean isAccountOfViewer { get; set; }
        public Boolean isPartnerOfThisViewer { get; set; }
        public Boolean isWaitingForPartnershipResponse { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsOrganization { get; set; }
        public Boolean isEmployerOfThisViewerAsUser { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsUser { get; set; }

      //  public KeyValuePair<String, String> OrganizationSuggestion { get; set; }
        public KeyValuePair<String, String> PartnerSuggestion { get; set; }
        public KeyValuePair<String, String> AllianceSuggestion { get; set; }


        public Boolean showPartnershipButton { get; set; }
        public Boolean enablePartnershipButton { get; set; }
        public String PartnershipButtonCaption { get; set; }
        public String PartnershipButtonActionName { get; set; }
        public String PartnershipButtonControllerName { get; set; }

        public Dictionary<String, String> Employees { get; set; }

        public Dictionary<String, String> Partners { get; set; } // partnership,contact
        public Dictionary<String, String> Alliances { get; set; }
        public Dictionary<String, String> Folders { get; set; }
        public ContentStreamView Wall { get; set; }
        public Boolean IsActive { get; set; }
    }
}
