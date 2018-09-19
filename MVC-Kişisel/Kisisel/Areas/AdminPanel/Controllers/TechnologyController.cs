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
    public class TechnologyController : Controller
    {
        // GET: AdminPanel/Technology
        TechnologyBLL _technology = new TechnologyBLL();
        // GET: AdminPanel/Category
        public ActionResult Index()
        {
            List<Technology> technologyList = _technology.GetAll();
            return View(technologyList);
        }

        [HttpPost]
        public ActionResult TechnologyAdd(string deger)
        {
            Technology technology = new Technology();
            technology.Name = deger;

            _technology.Add(technology);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult TechnologyUpdate(int id, string deger)
        {
            Technology technology = _technology.Get(id);
            technology.Name = deger;

            _technology.Update(technology);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult TechnologyDelete(int id)
        {

            Technology technology = _technology.Get(id);

            List<Project_Technology> project_Technology = _technology.GetProject_Technology(technology.Id);

            foreach (var item in project_Technology)
            {
                _technology.Project_TechnologyRemove(item);
            }

            _technology.Remove(technology);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}