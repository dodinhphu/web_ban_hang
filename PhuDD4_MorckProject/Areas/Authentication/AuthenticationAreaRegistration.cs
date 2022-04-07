using System.Web.Mvc;

namespace PhuDD4_MorckProject.Areas.Authentication
{
    public class AuthenticationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authentication";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // get login
            context.MapRoute(
                "Authentication_login",
                "Authentication/login",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            // get logout
            context.MapRoute(
                "Authentication_logout",
                "Authentication/logout",
                new { controller = "Logout", action = "Logout", id = UrlParameter.Optional }
            );

            // get register 
            context.MapRoute(
                "Authentication_register",
                "Authentication/register",
                new { controller = "Register", action = "Create", id = UrlParameter.Optional }
            );
            // get update register 
            context.MapRoute(
                "Authentication_Update_register",
                "Authentication/register/update",
                new { controller = "Register", action = "Update", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Authentication_default",
                "Authentication/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}