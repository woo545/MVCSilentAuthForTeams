using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace MVCSilentAuthForTeams.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public void SignOut()
        {
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

            HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }

        public ActionResult SignOutCallback()
        {
            if (Request.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //public ActionResult SignInCallBack()
        //{
        //    SetCookie("test", "test", "test");
        //    return RedirectToAction("Index", "Home");
        //}

        //private void SetCookie(string userid, string tenantId, string userName)
        //{            

        //    // And fake a login to create a membership cookie with OWIN cookie authentication.
        //    //Note we're not setting any sameSite attributes here.
        //    var claims = new[] { new Claim(ClaimTypes.NameIdentifier, "Dufus.Neanderthal") };
        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
            
        //    var ctx = HttpContext.GetOwinContext();
        //    var authManager = ctx.Authentication;
        //    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
        //    //}
        //}
    }
}
