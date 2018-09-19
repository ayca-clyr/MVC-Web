using MhrsWeb.Helper;
using MhrsWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Controllers
{
    public class HomeController : Controller
    {
        MhrsWebDBEntities db = new MhrsWebDBEntities();
        // GET: Homr
        [LoginRequired]
        public ActionResult Index()
        {
            Login loginUser = (Login)Session["CurrentUser"];
            Session["LoginFullName"] = loginUser.Kullanici.Name + " " + loginUser.Kullanici.Surname;


            return View();
        }
        public JsonResult TarihList()
        {
            List<string> tarihListesi15 = new List<string>();
            int counter = 0;
            while (tarihListesi15.Count != 15)
            {
                DateTime tarih = new DateTime();
                tarih = DateTime.Now.Date.AddDays(counter);
                if (tarih.DayOfWeek != DayOfWeek.Sunday && tarih.DayOfWeek != DayOfWeek.Saturday)
                    tarihListesi15.Add(tarih.ToShortDateString());
                counter++;
            }
            return Json(tarihListesi15, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SehirList()
        {
            List<SehirModel> sehirList;
            sehirList = db.Sehir.Select(x => new SehirModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(sehirList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IlceList(int Id)
        {
            List<IlceModel> ilceList;

            ilceList = db.Ilce.Where(x => x.SehirId == Id).Select(x => new IlceModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(ilceList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult HastaneList(int sehirId, int ilceId)
        {
            List<HastaneModel> hastaneList;

            hastaneList = db.Hastane.Where(x => (ilceId == 0) ? x.Ilce.SehirId == sehirId : x.IlceId == ilceId)
            .Select(x => new HastaneModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(hastaneList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult KlinikList(int ilceId, int hastaneId)
        {
            List<KlinikModel> klinikList = new List<KlinikModel>();

            if (ilceId != 0 && hastaneId != 0 || ilceId == 0 && hastaneId != 0)
            {
                List<int> klinikIdleri = new List<int>();
                klinikIdleri = db.Hastane_Klinik.Where(x => x.HastaneId == hastaneId).Select(x => x.KlinikId).ToList();

                foreach (var item in klinikIdleri)
                {
                    foreach (var item2 in db.Klinik)
                    {
                        if (item == item2.Id)
                        {
                            KlinikModel klinik = new KlinikModel();
                            klinik.Id = item2.Id;
                            klinik.Name = item2.Name;
                            klinikList.Add(klinik);
                        }
                    }

                }
            }
            else
            {
                klinikList = db.Klinik.Select(x => new KlinikModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }

            return Json(klinikList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DoktorList(int hastaneId, int klinikId)
        {
            List<DoktorModel> doktorList = new List<DoktorModel>();
            if (hastaneId > 0 && klinikId > 0)
            {
                doktorList = db.Doktor.Where(x => x.HastaneId == hastaneId && x.UzmanlıkId == klinikId).Select(
                    x => new DoktorModel()
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                    }).ToList();
            }
            return Json(doktorList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RandevuAra(RandevuAraModel model)
        {
            List<RandevuBilgileri> bilgiListesi = new List<RandevuBilgileri>();
            List<Ilce> ilceList = model.IlceId == 0 ? db.Ilce.Where(x => x.SehirId == model.SehirId).ToList() ?? new List<Ilce>() : db.Ilce.Where(x => model.IlceId == x.Id).ToList();

            List<Hastane> hastaneList = new List<Hastane>();
            if (model.HastaneId == 0)
            {
                foreach (var item in ilceList)
                {
                    foreach (var hastane in item.Hastane)
                        hastaneList.Add(hastane);
                }
            }
            else hastaneList = db.Hastane.Where(x => x.Id == model.HastaneId).ToList() ?? new List<Hastane>();

            List<Klinik> klinikList = new List<Klinik>();
            if (model.KlinikId == 0)
            {
                foreach (var item in hastaneList)
                {
                    foreach (var klinik in item.Hastane_Klinik)
                        klinikList.Add(klinik.Klinik);
                }
            }
            else klinikList = db.Klinik.Where(x => x.Id == model.KlinikId).ToList() ?? new List<Klinik>();

            List<Doktor> doktorList = new List<Doktor>();
            if (model.DoktorId == 0)
            {
                foreach (var item in klinikList)
                {
                    foreach (var doktor in item.Doktor)
                    {
                        if (hastaneList.Any(x => x.Id == doktor.HastaneId))
                            doktorList.Add(doktor);
                    }
                }
            }
            else doktorList = db.Doktor.Where(x => x.Id == model.DoktorId).ToList() ?? new List<Doktor>();

            List<RandvuSaati_Doktor> araListe = new List<RandvuSaati_Doktor>();
            foreach (var item in doktorList)
            {
                if (model.Tarih == null)
                {
                    foreach (var randevuSaati in item.RandvuSaati_Doktor)
                    {
                        if (randevuSaati.RandevuTarihi >= DateTime.Now.Date)
                            araListe.Add(randevuSaati);
                    }
                }
                else
                {
                    foreach (var randevuSaati in item.RandvuSaati_Doktor)
                    {
                        if (randevuSaati.RandevuTarihi == model.Tarih)
                            araListe.Add(randevuSaati);
                    }
                }
            }

            List<RandvuSaati_Doktor> yeniListe = new List<RandvuSaati_Doktor>();
            foreach (var item in araListe)
            {
                var sonuc = yeniListe.Any(x => (x.DoktorId == item.DoktorId) && (x.RandevuTarihi == item.RandevuTarihi));
                if (!sonuc) yeniListe.Add(item);
            }

            foreach (var item in yeniListe)
            {
                RandevuBilgileri randevuBilgisi = new RandevuBilgileri();
                randevuBilgisi.Doktor = db.Doktor.Where(x => x.Id == item.DoktorId).Select(
                    x => new DoktorModel()
                    {
                        Id = x.Id,
                        FullName = x.FullName
                    }
                    ).FirstOrDefault();
                randevuBilgisi.RandevuTarihi = item.RandevuTarihi.ToShortDateString();
                randevuBilgisi.Hastane = item.Doktor.Hastane.Name;
                randevuBilgisi.Klinik = item.Doktor.Klinik.Name;

                bilgiListesi.Add(randevuBilgisi);
            }
            return Json(bilgiListesi.OrderByDescending(x => x.RandevuTarihi), JsonRequestBehavior.AllowGet);
        }
        public JsonResult RandevuGoster(int doktorId, string randevuTarihi)
        {
            List<RandevuSaatBilgileri> bilgiList = new List<RandevuSaatBilgileri>();
            if (doktorId == 0)
                return Json(bilgiList, JsonRequestBehavior.AllowGet);

            List<RandvuSaati_Doktor> araListe = new List<RandvuSaati_Doktor>();

            DateTime tarih = DateTime.Parse(randevuTarihi).Date;
            araListe = db.RandvuSaati_Doktor.Where(x => x.DoktorId == doktorId && x.RandevuTarihi == tarih).ToList();

            foreach (var item in araListe)
            {
                RandevuSaatBilgileri bilgi = new RandevuSaatBilgileri();
                bilgi.RandevuSaatId = item.RandevuSaatiId;
                bilgi.saat = DateTime.Parse(item.RandevuSaati.Saat.ToString()).ToShortTimeString();
                bilgi.Durum = item.Durum;

                bilgiList.Add(bilgi);
            }
            return Json(bilgiList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SecilenRandevu(int doktorId, string tarih, int saatId)
        {
            Doktor doktor = db.Doktor.Where(x => x.Id == doktorId).FirstOrDefault();
            DateTime dTarih = DateTime.Parse(tarih).Date;
            RandvuSaati_Doktor randevuKontrol = db.RandvuSaati_Doktor.Where(x =>
            x.DoktorId == doktorId &&
            x.RandevuTarihi == dTarih &&
            x.RandevuSaatiId == saatId).FirstOrDefault();

            string userTC = Session["CurrentUserTC"].ToString();
            List<Randevu> gecmisRandevuList = db.Randevu.Where(x => x.LoginTC == userTC).ToList();

            bool kontrol = false;

            if (gecmisRandevuList != null)
                foreach (var item in gecmisRandevuList)
                    if (doktorId == item.DoktorId && item.Tarih >= DateTime.Now && item.Durum == true)
                        return Json(kontrol, JsonRequestBehavior.AllowGet);

            if (randevuKontrol.Durum == false)
                return Json(kontrol, JsonRequestBehavior.AllowGet);

            Randevu yeniRandevu = new Randevu();
            yeniRandevu.LoginTC = Session["CurrentUserTC"].ToString();
            yeniRandevu.Tarih = DateTime.Parse(tarih).Date;
            yeniRandevu.RandevuSaatiId = saatId;
            yeniRandevu.Durum = true;
            yeniRandevu.DoktorId = doktorId;
            yeniRandevu.Hastane_Klinik_Id = db.Hastane_Klinik.Where(x => x.KlinikId == doktor.Klinik.Id && x.HastaneId == doktor.HastaneId).FirstOrDefault().Id;

            try
            {
                db.Randevu.Add(yeniRandevu);
                db.SaveChanges();
                RandvuSaati_Doktor randevuUpdate = db.RandvuSaati_Doktor.Where(x => x.DoktorId == doktorId && x.RandevuTarihi == yeniRandevu.Tarih && x.RandevuSaatiId == saatId).FirstOrDefault();
                randevuUpdate.Durum = false;
                db.SaveChanges();

                kontrol = true;

                return Json(kontrol, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(kontrol, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RandevuGecmisi()
        {
            string userTC = Session["CurrentUserTC"].ToString();
            List<Randevu> randList = db.Randevu.Where(x => x.LoginTC == userTC).OrderByDescending(x => x.Tarih).ThenByDescending(x => x.RandevuSaatiId).ToList();

            List<RandevuGecmisiModel> gecmisRandevuList = new List<RandevuGecmisiModel>();

            foreach (var item in randList)
            {
                RandevuGecmisiModel gecmisRandevu = new RandevuGecmisiModel();
                string dTarih = DateTime.Parse(item.Tarih.ToString()).ToShortDateString() + " " + DateTime.Parse(item.RandevuSaati.Saat.ToString()).ToShortTimeString();

                gecmisRandevu.RandevuId = item.Id;
                gecmisRandevu.DoktorFullName = item.Doktor.FullName;
                gecmisRandevu.TarihVeSaat = dTarih;
                gecmisRandevu.HastaneAdı = item.Doktor.Hastane.Name;
                gecmisRandevu.KlinikAdı = item.Doktor.Klinik.Name;
                gecmisRandevu.RandevuDurumu = item.Durum;
                gecmisRandevuList.Add(gecmisRandevu);
            }
            return Json(gecmisRandevuList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult KullaniciBilgileri(string SeoText)
        {
            Login loginUser = (Login)Session["CurrentUser"];
            KullaniciBilgileriModel kullaniciBilgileri = new KullaniciBilgileriModel();
            if (loginUser == null)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız!');window.location = '/Login/Index';</script>");

            kullaniciBilgileri.Name = loginUser.Kullanici.Name;
            kullaniciBilgileri.Surname = loginUser.Kullanici.Surname;
            kullaniciBilgileri.DateOfBirth = DateTime.Parse(loginUser.Kullanici.DateOfBirth.ToString()).ToShortDateString();
            kullaniciBilgileri.Email = loginUser.Kullanici.Email;

            return View(kullaniciBilgileri);
        }
        [HttpPost]
        public ActionResult KullaniciBilgileri(Kullanici kullanici, string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {
            Md5Service md5Service = new Md5Service();
            string TC = Session["CurrentUserTC"].ToString();
            Login login = db.Login.Where(x => x.TC == TC).FirstOrDefault();

            if (login == null)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız!');window.location = '/Login/Index';</script>");

            if (login.Password != md5Service.Md5Sifre(eskiSifre))
                return Content("<script language='javascript' type='text/javascript'>alert('Eski Şifrenizi Yanlış Girdiniz.Lütfen Kontrol Ediniz!');window.location = '/Home/KullaniciBilgileri';</script>");

            try
            {
                if (((!string.IsNullOrWhiteSpace(yeniSifre)) && (string.IsNullOrWhiteSpace(yeniSifreTekrar))) ||
                    ((string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar))))
                    return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanlarından Birisini Doldurmadınız!');window.location = '/Home/KullaniciBilgileri';</script>");

                if ((!string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar)))
                {
                    if (yeniSifre != yeniSifreTekrar)
                        return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanları Aynı Değil!');window.location = '/Home/KullaniciBilgileri';</script>");
                    else login.Password = md5Service.Md5Sifre(yeniSifre);
                }

                if (kullanici.Email != null)
                {
                    Kullanici emailKontrol = db.Kullanici.Where(x => x.Email == kullanici.Email).FirstOrDefault();
                    if (emailKontrol != null && kullanici.Email != login.Kullanici.Email)
                        return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Email Adresi Başka Bir Kullanıcıya Ait!');window.location = '/Home/KullaniciBilgileri';</script>");
                    else login.Kullanici.Email = kullanici.Email;
                }

                db.SaveChanges();
                Session["CurrentUser"] = login;

                if (Response.Cookies.Get("CurrentPassword") != null)
                {
                    Response.Cookies.Get("CurrentPassword").Value = login.Password;
                    Response.Cookies.Get("CurrentPassword").Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Set(Response.Cookies.Get("CurrentPassword"));
                }

                return Content("<script language='javascript' type='text/javascript'>alert('Güncelleme işlemi başarıyla gerçekleşti!');window.location = '/Login/Index';</script>");
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Güncelleme Yapılamadı.Bir hata meydana geldi!');window.location = '/Home/KullaniciBilgileri';</script>");
            }
        }
        [HttpPost]
        public ActionResult RandevuIptalEt(int RandevuIptalId)
        {
            Randevu randevuIptal = db.Randevu.Where(x => x.Id == RandevuIptalId).FirstOrDefault();
            randevuIptal.Durum = false;

            bool kontrol = false;

            try
            {
                db.SaveChanges();
                RandvuSaati_Doktor randevuIptalUpdate = db.RandvuSaati_Doktor.Where(x => x.DoktorId == randevuIptal.DoktorId && x.RandevuTarihi == randevuIptal.Tarih && x.RandevuSaatiId == randevuIptal.RandevuSaatiId).FirstOrDefault();
                randevuIptalUpdate.Durum = false;
                db.SaveChanges();

                kontrol = true;

                return Json(kontrol, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(kontrol, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult YeniSifre(string yeniSifre, string yeniSifreTekrar)
        {
            Md5Service md5Service = new Md5Service();
            string TC = Session["CurrentUserTC"].ToString();
            Login login = db.Login.Where(x => x.TC == TC).FirstOrDefault();

            if (login == null)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız!');window.location = '/Login/Index';</script>");

            try
            {
                if (((!string.IsNullOrWhiteSpace(yeniSifre)) && (string.IsNullOrWhiteSpace(yeniSifreTekrar))) ||
                    ((string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar))))
                    return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanlarından Birisini Doldurmadınız!');window.location = '/Home/Index';</script>");

                if ((!string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar)))
                {
                    if (yeniSifre != yeniSifreTekrar)
                        return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanları Aynı Değil!');window.location = '/Home/Index';</script>");
                    else
                        login.Durum = false;
                    login.Password = md5Service.Md5Sifre(yeniSifre);

                }
                db.SaveChanges();
                Session["CurrentUser"] = login;

                if (Response.Cookies.Get("CurrentPassword") != null)
                {
                    Response.Cookies.Get("CurrentPassword").Value = login.Password;
                    Response.Cookies.Get("CurrentPassword").Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Set(Response.Cookies.Get("CurrentPassword"));
                }

                return Content("<script language='javascript' type='text/javascript'>alert('Şifreniz Başarıyla Güncellenmiştir!');window.location = '/Home/Index';</script>");
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Güncelleme Yapılamadı.Bir hata meydana geldi!');window.location = '/Home/Index';</script>");
            }
        }

    }
}
