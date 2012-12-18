using System.Collections.Generic;
using System.Web.Mvc;
 
using FHNWPrototype.Application.Controllers.UIViewModels.Organizations;
using FHNWPrototype.Application.Controllers.UIViewModels.Alliances;
 
using FHNWPrototype.Domain.Organizations;
 
using System;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class OrganizationsController : Controller
    {

  
 
      
        public OrganizationsController()
        {
            
        }

      

        public ActionResult Organization(string id)
        {
            //OrganizationServiceFacade organizationService = new OrganizationServiceFacade(new OrganizationServiceProxy());
            //"BCBCCE0E-7C9F-4386-98AA-1458F308E1C3"
            OrganizationViewModel organizationRetrieved = OrganizationService.GetOrganizationByKey(id);

            OrganizationView organizationView = new OrganizationView();
            //organizationView.Key = organizationRetrieved.Key;
            //organizationView.Name = organizationRetrieved.Name;
            //organizationView.Description = organizationRetrieved.Description;
           // organizationView.

            organizationView.Latitude = organizationRetrieved.Latitude;
            organizationView.Longitude =  organizationRetrieved.Longitude;

            Dictionary<string, string> coordinates = new Dictionary<string, string>();
            coordinates.Add("Partner1", "47.548807,7.587820");
            coordinates.Add("Partner2", "46.948432,7.440461");
            coordinates.Add("Partner3", "46.519595,6.632335");

            organizationView.PartnersCoordinates = coordinates;

            return View(organizationView);
        }



       


        public ActionResult Index()
        {
            //OrganizationServiceFacade organizationService = new OrganizationServiceFacade(new OrganizationServiceProxy());

            List<OrganizationViewModel> organizationsFound = OrganizationService.GetAllOrganizations();

            OrganizationsView organizationsView = new OrganizationsView();

            foreach (OrganizationViewModel item in organizationsFound)
            {
                organizationsView.Organizations.Add(item.Profile.BasicProfile.ReferenceKey , item.Profile.FullName );
            }

            return View(organizationsView);

        }



        //public ActionResult Alliance(string name)
        //{

        //    AllianceView allianceView = new AllianceView();

        //    allianceView.Name = name;
        //    allianceView.Description = "Description of alliance 1";
        //    allianceView.MemberOrganizations = new List<string>();
        //    allianceView.MemberOrganizations.Add("Coop");
        //    allianceView.MemberOrganizations.Add("Migros");
        //    allianceView.MemberOrganizations.Add("Emmi");
        //    allianceView.MemberOrganizations.Add("Galliker");

        //    return View(allianceView);

        //}

      

    }
}
