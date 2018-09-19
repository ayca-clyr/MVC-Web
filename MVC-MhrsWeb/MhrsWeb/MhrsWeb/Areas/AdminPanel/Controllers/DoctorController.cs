using MhrsWeb.Areas.AdminPanel.Helper;
using MhrsWeb.Areas.AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class DoctorController : Controller
    {
        MhrsWebDBEntities db = new MhrsWebDBEntities();
        public ActionResult Index()
        {
            List<Doktor> doctorList = db.Doktor.ToList();
            return View(doctorList);
        }
        public ActionResult Create()
        {
            DoctorViewModel model = new DoctorViewModel();
            model.cinsiyetList = db.Cinsiyet.ToList();
            model.klinikList = db.Klinik.ToList();
            model.hastaneList = db.Hastane.ToList();
            

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(Doktor doktor)
        {
            db.Doktor.Add(doktor);
            db.SaveChanges();

            

            Hastane_Klinik hastaKlinik = new Hastane_Klinik();
            hastaKlinik = db.Hastane_Klinik.Where(x => x.HastaneId == doktor.HastaneId && x.KlinikId == doktor.UzmanlıkId).FirstOrDefault();

            if(hastaKlinik == null)
            {
                Hastane_Klinik yeniHastaneKlinik = new Hastane_Klinik();
                yeniHastaneKlinik.HastaneId = (int)doktor.HastaneId;
                yeniHastaneKlinik.KlinikId = (int)doktor.UzmanlıkId;

                db.Hastane_Klinik.Add(yeniHastaneKlinik);
                db.SaveChanges();
            }

           

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id,string SeoText)
        {
            DoctorViewModel model = new DoctorViewModel();
            model.cinsiyetList = db.Cinsiyet.ToList();
            model.klinikList = db.Klinik.ToList();
            model.hastaneList = db.Hastane.ToList();
            model.doktor = db.Doktor.Where(x => x.Id == Id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Doktor doktor)
        {

            Doktor updatedDoktor = db.Doktor.Where(x => x.Id == doktor.Id).FirstOrDefault();
            updatedDoktor.FullName = doktor.FullName;
            updatedDoktor.CinsiyetId = doktor.CinsiyetId;
            updatedDoktor.UzmanlıkId = doktor.UzmanlıkId;
            updatedDoktor.HastaneId = doktor.HastaneId;

            db.SaveChanges();

            



            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            db.Doktor.Remove(db.Doktor.Where(x => x.Id == Id).FirstOrDefault());
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}