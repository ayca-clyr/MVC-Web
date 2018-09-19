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
    public class TarihController : Controller
    {

        MhrsWebDBEntities db = new MhrsWebDBEntities();

        // GET: AdminPanel/Tarih
        public ActionResult Index()
        {
            List<Doktor> doctorList = db.Doktor.ToList();
            return View(doctorList);
        }



        [HttpPost]
        public ActionResult Index(Doktor doktor)
        {
            RandevuSaatiViewModel model = new RandevuSaatiViewModel();

            model.tarihListesi15 = new List<DateTime>();
            model.doktor = db.Doktor.Where(x => x.Id == doktor.Id).FirstOrDefault();

            List<string> tarihListesi15 = new List<string>();
            int counter = 0;
            while (model.tarihListesi15.Count != 15)
            {
                DateTime tarih = new DateTime();
                tarih = DateTime.Now.Date.AddDays(counter);
                if (tarih.DayOfWeek != DayOfWeek.Sunday && tarih.DayOfWeek != DayOfWeek.Saturday)
                {
                    model.tarihListesi15.Add(tarih.Date);

                }
                counter++;
            }

            return View("TarihSec", model);
        }

        [HttpPost]
        public ActionResult TarihleriKaydet(int Id, DateTime CalismaTarihi)
        {

            RandvuSaati_Doktor kontrol = db.RandvuSaati_Doktor.Where(x => x.DoktorId == Id && x.RandevuTarihi == CalismaTarihi).FirstOrDefault();

            if (kontrol != null)
                return Content("<script language='javascript' type='text/javascript'>alert('Tarih Önceden Sisteme Eklenmiş...!!!');window.location = '/AdminPanel/Home';</script>");


            try
            {
                List<RandevuSaati> saatListesi = db.RandevuSaati.ToList();
                foreach (var item in saatListesi)
                {
                    RandvuSaati_Doktor kayit = new RandvuSaati_Doktor {
                        DoktorId = Id,
                        RandevuSaatiId = item.Id,
                        RandevuTarihi = CalismaTarihi,
                        Durum = true
                    };
    
                    //RandvuSaati_Doktor kayit = new RandvuSaati_Doktor();
                    //kayit.DoktorId = Id;
                    //kayit.RandevuSaatiId = item.Id;
                    //kayit.RandevuTarihi = CalismaTarihi;
                    //kayit.Durum = true;

                    db.RandvuSaati_Doktor.Add(kayit);
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Tarih Eklenirken bir hata oluştu !!');window.location = '/AdminPanel/Home';</script>");
            }

            return Content("<script language='javascript' type='text/javascript'>alert('Çalışma Tarihi Eklendi..');window.location = '/AdminPanel/Home';</script>");
        }




    }
}