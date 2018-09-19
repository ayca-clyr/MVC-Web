using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormMethods.Controllers
{
    public class TsubasaController : Controller
    {
        // GET: Tsubasa

        /*            
                   GET : QueryString olarak datayı gönderir. Bu neden tarayıcıya kaydedilebilir ve geçmişte görülebilir. Çünkü Id'si var ve bunun geçmişini görüyor. Yıldız olarak kaydetmek bile bunla sağlanıyor. Cach'lenebilir. Güvenli değildir. Url'de gönderildiği için karakter sınırlaması vardır. Yalnızca ASCII karakterler gönderilebilir.
                   POST : QueryString olarak gönderilmez. Haliyle Url'de görülmez. Bu nedenle tarayıcıya kadedilemez, geçmişte görülemez, Cach'lenemez, ama Güvenli. Her türlü data post ile gönderilebilir.
         */         
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AraGet(string ifade, string birDigerIfade)
        {
            /* return View("..");
             * Dediğimizde direk bize o sayfayı döndürüyordu. Aşağıda sonuc değerini string tutmamızın sebebi bu karıştırma olayı yaşanmasın diye. String dışında her türlü veri tipi kullanabilirsiniz. Bizde object tuttuk.
             */
            object result = ifade + " kelime GET yöntemi ile arandı. Diğer aranan kelime de : " + birDigerIfade;
            return View("Sonuc",result);
        }
        public ActionResult AraPost(string aranacakKelime)
        {
            object result = aranacakKelime + " kelimesi POST yöntemi ile arandı";
            return View("Sonuc", result);
        }
    }
}