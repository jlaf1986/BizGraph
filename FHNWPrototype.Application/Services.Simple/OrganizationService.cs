using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static  class OrganizationService
    {

       // private OrganizationRepository organizationRepository;

        //public OrganizationService()
        //{
        //   // organizationRepository = new OrganizationRepository();
        //}

     

        public static List<OrganizationViewModel> GetAllOrganizations()
        {
            

            IEnumerable<Organization> organizations = OrganizationRepository.FindAll();

            List<OrganizationViewModel> result = new List<OrganizationViewModel>();

            foreach (Organization item in organizations)
            {
                OrganizationViewModel itemview = new OrganizationViewModel();
                itemview.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=item.Key.ToString(), AccountType= AccountType.Organization  }, FullName=item.Name, Description1=item.Description  };
                itemview.Latitude = item.HeadquatersLocation.Latitude;
                itemview.Longitude = item.HeadquatersLocation.Longitude;
              
                result.Add(itemview);
            }

            return result;
        }

        public static OrganizationViewModel  GetOrganizationByKey(string organizationKey)
        {
            
            Organization organization = OrganizationRepository.FindBy(new Guid(organizationKey));

            OrganizationViewModel result = new OrganizationViewModel();
         
            result.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=organization.Key.ToString(), AccountType= AccountType.Organization  }, FullName=organization.Name, Description1=organization.Description   };
            result.Latitude = organization.HeadquatersLocation.Latitude;
            result.Longitude = organization.HeadquatersLocation.Longitude;
            

            return result;
        }

        public static OrganizationViewModel GetOrganizationByUserAccountKey(string userAccountKey)
        {
            Organization organization = OrganizationRepository.GetOrganizationByUserAccountKey(new Guid(userAccountKey));

            OrganizationViewModel result = new OrganizationViewModel();

            //result.Key = organization.Key.ToString();
            //result.Name = organization.Name;
            //result.Description = organization.Description;
            result.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=organization.Key.ToString(), AccountType= AccountType.Organization  }, FullName=organization.Name, Description1=organization.Description  };
            result.Latitude = organization.HeadquatersLocation.Latitude;
            result.Longitude = organization.HeadquatersLocation.Longitude;
            

            return result;

        }

        public static OrganizationViewModel GetOrganizationByOrganizationAccountKey(string organizationAccountKey)
        {
            Organization organization = OrganizationRepository.GetOrganizationByOrganizationAccountKey(new Guid(organizationAccountKey));

            OrganizationViewModel result = new OrganizationViewModel();
            result.Profile = new CompleteProfileViewModel { BasicProfile = new BasicProfileViewModel { ReferenceKey=organization.Key.ToString(), AccountType=AccountType.Organization   }, FullName=organization.Name, Description1=organization.Description  };
            
            return result;
        }

      

    }
}
