using BusinessLayer;
using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class CategoryController : Controller
    {
        CategoryBLL _categoryBLL = new CategoryBLL();
        // GET: AdminPanel/Category
        public ActionResult Index()
        {
            List<Category> categoryList = _categoryBLL.GetAll();
            return View(categoryList);
        }

        [HttpPost]
        public ActionResult CategoryAdd(string deger)
        {
            Category category = new Category();
            category.Name = deger;

            _categoryBLL.Add(category);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(int id, string deger)
        {
            Category category = _categoryBLL.Get(id);
            category.Name = deger;

            _categoryBLL.Update(category);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CategoryDelete(int id)
        {

            Category category = _categoryBLL.Get(id);
            _categoryBLL.Remove(category);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}