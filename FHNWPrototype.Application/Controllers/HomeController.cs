using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

//using Microsoft.IdentityModel.Claims;
using System.Security.Claims;
using FHNWPrototype.Application.Controllers.UIViewModels.Home;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class HomeController : Controller
    {



        [Authorize]
        public ActionResult Index()
        {
            //UserAccountPrincipal thisUser = (UserAccountPrincipal) User;
            //ClaimsIdentity thisIdentity = (ClaimsIdentity) thisUser.Identity;

            //ViewBag.Message = "Homepage ->User:" + thisIdentity.Name + " AuthenticationType:" + thisUser.Identity.AuthenticationType;
           // ClaimsPrincipal principal = User as ClaimsPrincipal;
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;

            List<String> claims = new List<string>();

            foreach (Claim claim in identity.Claims)
            {
                claims.Add("issuer:" + claim.Issuer + "-value type:" + claim.ValueType + "-value:" + claim.Value + "-originalIssuer:" + claim.OriginalIssuer  );
            }

            ViewBag.Message = "User: " + User.Identity.Name;
            ViewBag.Claims = claims;
            //return View("Welcome");
            return View();
        }

        //   [Authorize]
        public ActionResult About()
        {
            ViewBag.User = "";
            return View();
        }

        //
        // GET: /UserAccount/Login

        //[AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /UserAccount/Login

        [HttpPost]
        //[AllowAnonymous]
        //   [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            //if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            //{
            //    return RedirectToLocal(returnUrl);
            //}

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /UserAccount/LogOff

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    WebSecurity.Logout();

        //    return RedirectToAction("Index", "Home");
        //}

        //
        // GET: /UserAccount/Register

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        ////
        //// POST: /UserAccount/Register

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Attempt to register the user
        //        try
        //        {
        //            WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
        //            WebSecurity.Login(model.UserName, model.Password);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        catch (MembershipCreateUserException e)
        //        {
        //            ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

    }
}
