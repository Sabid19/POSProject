using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using POSWeb.Models.Account;
using POSWeb.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using System.Security.Claims;
using POSWeb.App_Start;

namespace POSWeb.Controllers.Account
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserManager usermanager = Request.GetOwinContext().Get<ApplicationUserManager>();

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email,PasswordHash=new PasswordHasher().HashPassword(model.Password) };
                var result = usermanager.Create(user);
                if (result.Succeeded)
                {
                    ApplicationSignInManager signinManager = Request.GetOwinContext().Get<ApplicationSignInManager>();
                     signinManager.SignIn(user,false,false);  
                                 
                    return RedirectToAction("Index", "Home");
                }         
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}