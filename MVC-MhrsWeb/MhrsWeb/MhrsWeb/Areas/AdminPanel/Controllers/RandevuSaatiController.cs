using MhrsWeb.Areas.AdminPanel.Helper;
using MhrsWeb.Areas.AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MhrsWeb.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class RandevuSaatiController : Controller
    {

        MhrsWebDBEntities db = new MhrsWebDBEntities();


        public ActionResult Index()
        {
            List<Doktor> doctorList = db.Doktor.ToList();
            return View(doctorList);
        }
        [HttpPost]
        public ActionResult Index(Doktor doktor)
        {
            RandevuSaatiViewModel model = new RandevuSaatiViewModel();
            model.doktor = db.Doktor.Where(x => x.Id == doktor.Id).FirstOrDefault();

            model.tarihListesi15 = new List<DateTime>();
            DateTime gun = DateTime.Now.Date;
            List<DateTime> araTablo = db.RandvuSaati_Doktor.Where(x => x.DoktorId == doktor.Id && x.RandevuTarihi >= gun)
                .Select(x => x.RandevuTarihi)
                .Distinct()
                .ToList();

            model.tarihListesi15 = araTablo;


            return View("UpdateTarihi", model);
        }
        //Buralarda biyerlerde UpdateTarih Viewi çalışıyor.




        [HttpPost]
        public ActionResult TransferPostMethod(int Id, string RandevuTarihi, int[] Saat)
        {
            if (Saat == null)
            {
                RandevuSaatiViewModel model = new RandevuSaatiViewModel();
                model.doktor = db.Doktor.Where(x => x.Id == Id).FirstOrDefault();
                model.doktorSaatTarihList = db.RandvuSaati_Doktor.Where(x => x.DoktorId == Id).ToList();
                model.randevuSaatleri = db.RandevuSaati.ToList();
                model.secilenRandevuTarihi = RandevuTarihi;
                return View("UpdateSaat", model);
            }
            else
            {
                DateTime tarih = DateTime.Parse(RandevuTarihi);
                List<RandvuSaati_Doktor> orijinalListe = db.RandvuSaati_Doktor
                    .Where(x => x.DoktorId == Id && x.RandevuTarihi == tarih)
                    .ToList();


                List<RandevuSaati> saatList = new List<RandevuSaati>();
                saatList = db.RandevuSaati.ToList();

                foreach (var saatItem in Saat)
                {
                    if (saatList.Where(x => x.Id == saatItem).Any())
                    {
                        orijinalListe.Where(x => x.RandevuSaatiId == saatItem).FirstOrDefault().Durum = true;
                        var data = saatList.Where(x => x.Id == saatItem).FirstOrDefault();
                        saatList.Remove(data);
                    }
                }
                foreach (var item in saatList)
                {
                    orijinalListe.Where(x => x.RandevuSaatiId == item.Id).FirstOrDefault().Durum = false;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }
        public ActionResult UpdateSaat()
        { return null; }








    }
}