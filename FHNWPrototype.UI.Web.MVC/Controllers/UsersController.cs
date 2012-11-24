using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FHNWPrototype.Domain.Users;
using System.Drawing;
using FHNWPrototype.Application.Controllers.UIViewModels.Users;
 
using FHNWPrototype.Application.Controllers.UIViewModels.UserAccounts;
using System.IO;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class UsersController : Controller
    {

        UserService userService = new UserService();

        public UsersController()
        {
        }

    

        public ActionResult GetUser(string id)
        {
            

            UserView userView = new UserView();

            //User userFound = userService.GetUserByKey("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0");
            UserViewModel userFound = userService.GetUserByKey(id);
            userView.Accounts = new Dictionary<string, string>();

           // List<UserAccountViewModel> userAccounts = userService.GetAllAccountsByUserKey(id);

            userView.Accounts = userFound.UserAccounts;
            userView.FirstName = userFound.FirstName;
            userView.LastName = userFound.LastName;
            userView.Key = userFound.Key;
            

            return View(userView);
        }
        /// <summary>
        ///     Return an image from a controller
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="http://blogs.msdn.com/b/miah/archive/2008/11/13/extending-mvc-returning-an-image-from-a-controller-action.aspx"/>
        /// <returns></returns>
        public FileContentResult GetUserProfilePictureByUserKey(string id)
        {
           

           // User userFound = userService.GetUserByKey("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0");

            byte[] pictureFound = userService.GetProfilePictureByUserKey(id);

            return File(pictureFound, "image/jpg");
        }

        //public ActionResult GetProfilePicture(string id)
        //{
        //    byte[] image = GenerateImage();
        //    return File(image, "image/jpg");
        //}

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
             Image returnImage =  Image.FromStream(ms);
            return returnImage;
        }

        [HttpGet]
        public ActionResult Index()
        {
          

            UsersView usersView = new UsersView();

            List<UserViewModel> usersFound = userService.GetAllUsers();

            foreach (UserViewModel item in usersFound)
            {
                usersView.Users.Add(item.Key, item.FirstName + " " + item.LastName); 
            }

            return View(usersView);
         
        }

        //public ActionResult Accounts()
        //{

    

        //    UserAccountsView accountsView = new UserAccountsView();
        //    accountsView.UserAccounts = new Dictionary<string, string>();

        //    List<UserAccountViewModel> useraccounts = userService.GetAllAccountsByUserKey("BCBCCE0E-7C9F-4386-98AA-1458F308E1A0");

        //    foreach (UserAccountViewModel item in useraccounts )
        //    {
        //        accountsView.UserAccounts.Add(item.UserAccountKey, item.Email);
        //    }

      

        //    return View(accountsView);
        //}

    }
}
