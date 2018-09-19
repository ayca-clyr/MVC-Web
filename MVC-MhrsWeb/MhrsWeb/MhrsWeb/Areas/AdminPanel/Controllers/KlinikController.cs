using MhrsWeb.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class KlinikController : Controller
    {
        MhrsWebDBEntities db = new MhrsWebDBEntities();
        public ActionResult Index()
        {
            List<Klinik> klinikList = db.Klinik.ToList();
            return View(klinikList);
        }

       
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Klinik klinik)
        {
            Klinik newKlinik = new Klinik
            {
                Name = klinik.Name
            };

            db.Klinik.Add(newKlinik);
            db.SaveChanges();




            return RedirectToAction("Index");
        }


        public ActionResult Edit(string SeoText, int Id)
        {
            Klinik klinik = db.Klinik.Where(x => x.Id == Id).FirstOrDefault();
            return View(klinik);
        }

        [HttpPost]
        public ActionResult Edit(Klinik klinik)
        {
            Klinik editKlinik = db.Klinik.Where(x => x.Id == klinik.Id).FirstOrDefault();
            editKlinik.Name = klinik.Name;

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            Klinik klinik = db.Klinik.Where(x => x.Id == Id).FirstOrDefault();

            db.Klinik.Remove(klinik);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}