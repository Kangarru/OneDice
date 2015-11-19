using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneDice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Home", action = "Login" }
            );
            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "Home", action = "Register" }
            );
            routes.MapRoute(
                name: "Reminder",
                url: "reminder",
                defaults: new { controller = "Home", action = "Reminder" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FrontEnd", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
