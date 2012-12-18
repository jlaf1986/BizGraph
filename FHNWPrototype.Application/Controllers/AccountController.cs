using FHNWPrototype.Application.Controllers.UIViewModels.Security;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SecurityService securityService = null;

        public AccountController()
        {
            securityService = new SecurityService(); 
        }

        public ActionResult Index()
        {
            CompleteProfile  profile = (CompleteProfile )Session["myProfile"];

            if (profile.BasicProfile.ReferenceType== AccountType.OrganizationAccount )
            {
                return RedirectToAction("Index", "OrganizationAccounts");
            }
            if (profile.BasicProfile.ReferenceType == AccountType.UserAccount)
            {
                return RedirectToAction("Index", "UserAccounts");
            }
            return null;
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginSystemAccountView model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                SystemAuthenticationTokenViewModel tokenVM = securityService.AttemptAuthentication(model.Email, model.Password);
                if (tokenVM.IsAuthenticated)
                {

                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    Session.Clear();

                    CompleteProfile myNewProfile = new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = new Guid(tokenVM.MyProfile.BasicProfile.ReferenceKey), ReferenceType = tokenVM.MyProfile.BasicProfile.AccountType }, FullName = tokenVM.MyProfile.FullName, Description1 = tokenVM.MyProfile.Description1, Description2 = tokenVM.MyProfile.Description2 };
                      
                    if (Session["myProfile"] == null)
                    {
                         Session.Add("myProfile",myNewProfile );
                    }
                    else
                    {
                        Session["myProfile"] = myNewProfile;
                    }

                    if (tokenVM.MyProfile.BasicProfile.AccountType  == AccountType.OrganizationAccount)
                    {
                        return RedirectToAction("Index", "OrganizationAccounts");
                    }

                    if (tokenVM.MyProfile.BasicProfile.AccountType  == AccountType.UserAccount)
                    {
                        return RedirectToAction("Index", "UserAccounts");
                    }

                    ModelState.AddModelError("", "Something happened, we can't let you go on =-/ ");
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "The email or password provided is incorrect.");
                    return View(model);
                }
          
            }
            else
            {
                ModelState.AddModelError("", "The email or password provided is incorrect.");
                return View(model);
            }

        }

        
        //[HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

    }
}
