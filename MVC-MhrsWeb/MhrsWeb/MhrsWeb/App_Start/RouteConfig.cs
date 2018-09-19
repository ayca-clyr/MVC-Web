using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MhrsWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "KullaniciBilgileri",
            "kullanici-bilgileri/{SeoText}",
            new { controller = "Home", action = "KullaniciBilgileri"},
            namespaces: new[] { "MhrsWeb.Controllers" }
            );

            routes.MapRoute(
           "sifremi-unuttum",
           "sifremi-unuttum",
           new { controller = "Login", action = "SifremiUnuttum" },
           namespaces: new[] { "MhrsWeb.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MhrsWeb.Controllers" }
            );
        }
    }
}
