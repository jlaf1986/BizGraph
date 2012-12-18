using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Geographics;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.OrganizationAccounts
{
    public class OrganizationAccountView
    {
      //  public Dictionary<String, String> OrganizationAccounts { get; set; }

        public CompleteProfileView   Profile { get; set; }
        //public String OrganizationAccountNameOfThisProfile { get; set; }
        //public String OrganizationAccountDescriptionOfThisProfile { get; set; }
        //public KeyValuePair<String, String> OrganizationOfThisProfile { get; set; }

        public String Email { get; set; }

        //Properties related with viewer of the account
        public Boolean IsThisMyOwnProfile { get; set; }
        public Boolean IsThisProfileAPartnerOfMine { get; set; }
        public Boolean isWaitingForPartnershipResponse { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsOrganization { get; set; }
        public Boolean isEmployerOfThisViewerAsUser { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsUser { get; set; }
        public GeoLocationView MyGeoLocation { get; set; }

        public Boolean ShowPartnershipButtonForThisProfile { get; set; }
        public Boolean EnablePartnershipButtonForThisProfile { get; set; }
        public String PartnershipButtonCaptionForThisProfile { get; set; }
        public String PartnershipButtonActionNameForThisProfile { get; set; }
        public String PartnershipButtonControllerNameForThisProfile { get; set; }

        public List<CompleteProfileView> SisterDivisionsOfThisProfile { get; set; }
        public List<CompleteProfileView> EmployeesOfThisProfile { get; set; }
        public List<CompleteProfileView> PartnersOfThisProfile { get; set; } 
        public List<CompleteProfileView> AlliancesOfThisProfile { get; set; }

        public Dictionary<String, String> FoldersOfThisProfile { get; set; }
        public ContentStreamView WallOfThisProfile { get; set; }
        public Boolean IsThisProfileStillActive { get; set; }
    }
}
