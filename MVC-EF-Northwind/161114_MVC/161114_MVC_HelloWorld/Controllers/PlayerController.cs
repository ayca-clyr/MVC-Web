using _161114_MVC_HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161114_MVC_HelloWorld.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            return View(DummyData.Players);
        }
        public ActionResult Detail(int id)
        {
            Player player = DummyData.Players.SingleOrDefault(p => p.Id == id);  // Değer getirsin veya getirmesin. Single diyorsak kayıt dönmediğinde patlaması demek. // FirstOrDefaultla farkı ise firstte aynı id'ye sahipse ilkini getirir. Single ise patlatır.

            if (player != null)
            {
                return View(player);
            }
            else
            {
                return HttpNotFound();
            }

            
        }
    }
}