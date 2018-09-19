using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _161125_Area_Intro
{
    public class RouteConfig
    {
        // Çakışma meydana geldiği için Home'dan 2 tane var. Hangisini kullanacağını belirlemek için namespaces kısmını ekleyip solution adını yazıyoruz.
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "_161125_Area_Intro.Controllers" }
            );
        }
    }
}
