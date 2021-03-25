
using System.Configuration;
using System.Web;
using System.Web.Mvc;

using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace MVCSilentAuthForTeams.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult msteamsSilent() { LoadViewBags(); return PartialView(); }

            // GET: Auth
            public ActionResult msteamsSilentStart()
            {
                LoadViewBags();
                return PartialView();
            }
            public ActionResult msteamsSilentEnd()
            {
                LoadViewBags();
                //SetCookie();
                return PartialView();
            }

            private void LoadViewBags()
            {
                ViewBag.ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
            }

        //public void SetCookies()
        //{
        //    const string CookieName = "sampleCookie";
        //    if (Request.Cookies[CookieName] == null)
        //    {
        //        // Create the cookie
        //        HttpCookie sameSiteCookie = new HttpCookie(CookieName);

        //        // Set a value for the cookie
        //        sameSiteCookie.Value = "sample";

        //        // Set the secure flag, which Chrome's changes will require for SameSite none.
        //        // Note this will also require you to be running on HTTPS
        //        sameSiteCookie.Secure = true;

        //        // Set the cookie to HTTP only which is good practice unless you really do need
        //        // to access it client side in scripts.
        //        sameSiteCookie.HttpOnly = true;

        //        // Add the SameSite attribute
        //        sameSiteCookie.SameSite = SameSiteMode.Lax;

        //        // Add the cookie to the response cookie collection
        //        Response.Cookies.Add(sameSiteCookie);
        //    }

        //    // Create a session variable to get a session cookie created.
        //    Session["sample"] = "sample";

        //    // And fake a login to create a membership cookie with OWIN cookie authentication.
        //    // Note we're not setting any sameSite attributes here.
        //    var claims = new[] { new Claim(ClaimTypes.NameIdentifier, "username") };
        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
        //    var ctx = HttpContext.GetOwinContext();
        //    var authManager = ctx.Authentication;
        //    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
        //}
    }
}