using BusinessLayer;
using Kisisel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Controllers
{
    public class HomeController : Controller
    {
        PeopleBLL _peopleBLL = new PeopleBLL();
        // GET: Home
        public ActionResult Index()
        {
            PageModel model = new PageModel();
            model.people = _peopleBLL.GetAll().FirstOrDefault();
            model.profilImage = _peopleBLL.GetImageForId(model.people.ImageId);
            model.categoryList = _peopleBLL.GetCategoryList();
            return View(model);
        }
    }
}