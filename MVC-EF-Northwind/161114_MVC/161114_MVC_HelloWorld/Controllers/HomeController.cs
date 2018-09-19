using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161114_MVC_HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // BizimSiteDomaini.com/Home/Index
        // localhost:21864/Home/Index
        // localhost:21864/Home
        // localhost:2186
        // (Yukardaki tüm yazılar bize Index'i çağrıcak. Yani View'i döndürecek.)
        // Methodların adı artık Action'dur.

        // Control Eklerken kullandığımız isim View altında direk çıkar.

        // Önce Controller(Home) Action (Index) Parametre alıp almaması (string id)
        public ActionResult Index()
        {
            return View();  // Ekrana View döndürür.
        }

        /*
         * Sadece View Döndürür
         * 
        public ViewResult About()
        {
            return View();
        }
        */

        // localhost:21864/Home/About/id
        // View'de yazdığımız Home altındaki cshtml ile burdaki method adı aynı olmalı yoksa hata fırlatır. (About = About)
        public ActionResult About(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ToLower() == "en")
            {
                return View();
            }
            else if(id.ToLower() == "tr")
            {
                // url'de genede About yazar. Hakkında sayfasını çağırsan bile. Url'de view değil Action ismi yazar. Bunun Action ismide About'dur.
                return View("Hakkinda");

                // Eğer başka bir yerde bu Tr varsa yani başka classda hangisini çekmek istiyorsak bu şekilde uzun uzun yazmamız gerekiyor.
                //return View("~/Views/Tr/Home/Hakkinda.cshtml");
                //return View("~/Tsubasa/Ozara/Hakkinda.cshtml");  // Tsubasa (klasöründe) Ozara (klasöründeki) Hakkinda.cshtml 


            }
            //Response.StatusCode = 404;
            // Bulunamadı
            //return HttpNotFound();

            //return View("Index"); 
            // Yanlış bir kullanım Url kısmına bakarsak Home/About/En/Index geliyor. Ve Breakpointde View'in içine girmiyor, içindeki işlemleri de görmemiş olucak.
            
            return RedirectToAction("Index"); 
            // Doğru Kullanım. Url kısmına baktığımızda Home/Index yani direk anasayfaya yönendirdik. Methodun içine girdi ve içinde işlem varsa onları da görmüş olucak.
        }
    }
}