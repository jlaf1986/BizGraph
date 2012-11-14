using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.AllianceMemberships.States;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static class OrganizationRepository //: IOrganizationRepository
    {

        //private FHNWPrototypeDB db = null;

        // public OrganizationRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}

        public static void Save(Organization entity)
        {
            throw new NotImplementedException();
        }

        public static void Add(Organization entity)
        {
            throw new NotImplementedException();
        }

        public static void Remove(Organization entity)
        {
            throw new NotImplementedException();
        }

        public static Organization FindBy(Guid key)
        {

            Organization result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = (from organization in db.Organizations
                                                    .Include("Location")
                          where organization.Key == key
                          select organization).FirstOrDefault();

                return result;
            }
        }


        public static byte[] GetHeaderPictureByOrganizationKey(Guid key)
        {
            byte[] result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = db.Organizations.SingleOrDefault(x => x.Key == key).HeaderPicture;


                return result;
            }
        }

        public static byte[] GetHeaderPictureByOrganizationAccountKey(Guid key)
        {
            byte[] result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result =  db.OrganizationAccounts 
                          .Include("Organization")
                          .SingleOrDefault(x=> x.Key==key).Organization.HeaderPicture;
                        
                return result;
            }
        }

        public static byte[] GetHeaderPictureByUserAccountKey(Guid key)
        {
            byte[] result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = db.UserAccounts
                                    .Include("OrganizationAccount.Organization")
                                    .SingleOrDefault(x => x.Key == key).OrganizationAccount.Organization.HeaderPicture;


                return result;
            }
        }

        public static Organization GetOrganizationByUserAccountKey(Guid key)
        {
            Organization  result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = db.UserAccounts.Single(x => x.Key == key).OrganizationAccount.Organization;

                return result;
            }
        }

        public static Organization GetOrganizationByOrganizationAccountKey(Guid key)
        {
            Organization result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = db.OrganizationAccounts.Include("Organization").SingleOrDefault(x=> x.Key==key).Organization;
                return result;
            }
        }


        public static IEnumerable<Organization> FindAll()
        {
            IEnumerable<Organization> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from organizations in db.Organizations
                         select organizations;


                return result;
            }
        }

        public static IEnumerable<Organization> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Organization> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
 
      
    }
}
