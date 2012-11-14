using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain._Base.Repositories;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static class UserRepository //: IUserRepository
    {
        //private FHNWPrototypeDB db = null;

        //public UserRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //   // db = new FHNWPrototypeDB();
        //}

        public static void Save(User entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                User foundUser = null;
                var results = from user in db.Users
                              where user.Key == entity.Key
                              select user;
                foundUser = results.FirstOrDefault();
                foundUser.FirstName = entity.FirstName;
                db.SaveChanges();
            }
        }

        public static void Add(User entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
        }

        public static void Remove(User entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.Users.Remove(entity);
                db.SaveChanges();
            }
        }

        public static User FindBy(Guid key)
        {

            User foundUser = null;
            using (var db = new FHNWPrototypeDB())
            {
                foundUser = db.Users.Single(x => x.Key == key);
                return foundUser;
            }
         
        }

        public static Byte[] GetProfilePictureByUserKey(Guid key)
        {

            Byte[] foundPicture = null;
            using (var db = new FHNWPrototypeDB())
            {
                foundPicture = db.Users.Single(x => x.Key == key).ProfilePicture;
                return foundPicture;
            }
           
        }

        public static IEnumerable<User> FindAll()
        {
            IEnumerable<User> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from user in db.Users
                             select user;
                return result;
            }
         
        }

        public static IEnumerable<User> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<User> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<UserAccount> GetAllAccountsByUserKey(Guid key)
        {
            IEnumerable<UserAccount> results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = from userAccounts in db.UserAccounts
                          where userAccounts.User.Key == key
                          select userAccounts;
                return results;
            }
         
        }

    }
}
