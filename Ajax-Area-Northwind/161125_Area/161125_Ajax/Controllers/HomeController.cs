using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161125_Ajax.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        northwindEntities _dbContext;

        public HomeController()
        {
            _dbContext = new northwindEntities();
        }
        public ActionResult Index()
        {
            return View();
        }

        // Üstteki View methoduyla return olduğu için sayfa yenilenirken. Aşağıdaki Json ile geri dönüş yaptığı için 
        public JsonResult GetCategory(int id)
        {
            Categories cat = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            return Json(cat, JsonRequestBehavior.AllowGet); // Cat gönderiyoruz ve bunu Json'un gönderdiğini kanıtlamak için JsonRequestBehavior yazdık.

        }
    }
}