using System.Web.Mvc;

namespace _161125_Area_Intro.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        // RouteConfig'le aynı işlemi yapıyor.Admin tarafına ulaşmak istediğimizde bize hata veriyor. Çünkü controller kısmı yok. Bu yüzden Controller="Home" ekliyoruz.
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}