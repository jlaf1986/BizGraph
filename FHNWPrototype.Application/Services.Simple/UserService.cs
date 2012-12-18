using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public class UserService
    {
       // private UserRepository userRepository;

        public UserService()
        {
          //  userRepository = new UserRepository();
        }

        public List<UserViewModel> GetAllUsers()
        {
            

            IEnumerable<User> users = UserRepository.FindAll();

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (User item in users)
            {
                

                result.Add(Converters.ConvertUserToViewModel(item));
            }

            return result;
        }

        public UserViewModel GetUserByKey(string key)
        {


            User userRetrieved = UserRepository.FindBy(new Guid(key));

             
          

            return Converters.ConvertUserToViewModel(userRetrieved);
        }

        public List<UserAccountViewModel> GetAllAccountsByUserKey(string userKey)
        {


            IEnumerable<UserAccount> accounts = UserRepository.GetAllAccountsByUserKey(new Guid(userKey));

            List<UserAccountViewModel> result = new List<UserAccountViewModel>();

            foreach (UserAccount item in accounts)
            {
                 
                result.Add(Converters.ConvertUserAccountToViewModel(item));
            }

            return result;
          
        }

        public byte[] GetProfilePictureByUserKey(string userKey)
        {
            
            byte[] profilePicture = null;

            profilePicture = UserRepository.GetProfilePictureByUserKey(new Guid(userKey));
            

            return profilePicture;
        }

    

       

    }
}
