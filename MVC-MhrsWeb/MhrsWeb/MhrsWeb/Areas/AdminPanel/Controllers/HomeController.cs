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
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult KullaniciBilgileri()
        {

            Login loginUser = (Login)Session["User"];


            KullaniciBilgileriModel kullaniciBilgileri = new KullaniciBilgileriModel();
            if (loginUser == null)

                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız!');window.location = '/AdminPanel/Login/Index';</script>");

            kullaniciBilgileri.Name = loginUser.Kullanici.Name;
            kullaniciBilgileri.Surname = loginUser.Kullanici.Surname;
            kullaniciBilgileri.DateOfBirth = DateTime.Parse(loginUser.Kullanici.DateOfBirth.ToString()).ToShortDateString();
            kullaniciBilgileri.Email = loginUser.Kullanici.Email;

            return View(kullaniciBilgileri);
        }

        [HttpPost]
        public ActionResult KullaniciBilgileri(Kullanici kullanici, string eskiSifre, string yeniSifre, string yeniSifreTekrar)
        {

            MhrsWebDBEntities db = new MhrsWebDBEntities();
            MhrsWeb.Helper.Md5Service md5Service = new MhrsWeb.Helper.Md5Service();
            string TC = Session["UserTC"].ToString();
            Login login = db.Login.Where(x => x.TC == TC).FirstOrDefault();

            if (login == null)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu. Lütfen Sisteme Tekrar Giriş Yapınız!');window.location = '/AdminPanel/Home/Index';</script>");

            if (login.Password != md5Service.Md5Sifre(eskiSifre))
                return Content("<script language='javascript' type='text/javascript'>alert('Eski Şifrenizi Yanlış Girdiniz.Lütfen Kontrol Ediniz!');window.location = '/AdminPanel/Home/KullaniciBilgileri';</script>");

            try
            {
                if (((!string.IsNullOrWhiteSpace(yeniSifre)) && (string.IsNullOrWhiteSpace(yeniSifreTekrar))) ||
                    ((string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar))))
                    return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanlarından Birisini Doldurmadınız!');window.location = '/AdminPanel/Home/KullaniciBilgileri';</script>");

                if ((!string.IsNullOrWhiteSpace(yeniSifre)) && (!string.IsNullOrWhiteSpace(yeniSifreTekrar)))
                {
                    if (yeniSifre != yeniSifreTekrar)
                        return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Yeni Şifre Alanları Aynı Değil!');window.location = '/AdminPanel/Home/KullaniciBilgileri';</script>");
                    else login.Password = md5Service.Md5Sifre(yeniSifre);

                }

                if (kullanici.Email != null)
                {
                    Kullanici emailKontrol = db.Kullanici.Where(x => x.Email == kullanici.Email).FirstOrDefault();
                    if (emailKontrol != null && kullanici.Email != login.Kullanici.Email)
                        return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz Email Adresi Başka Bir Kullanıcıya Ait!');window.location = '/AdminPanel/Home/KullaniciBilgileri';</script>");
                    else login.Kullanici.Email = kullanici.Email;
                }

                db.SaveChanges();
                Session["User"] = login;

                if (Response.Cookies.Get("Password") != null)
                {
                    Response.Cookies.Get("Password").Value = login.Password;
                    Response.Cookies.Get("Password").Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Set(Response.Cookies.Get("Password"));
                }

                return Content("<script language='javascript' type='text/javascript'>alert('Güncelleme işlemi başarıyla gerçekleşti!');window.location = '/AdminPanel/Home/Index';</script>");
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Güncelleme Yapılamadı.Bir hata meydana geldi!');window.location = '/AdminPanel/Home/KullaniciBilgileri';</script>");
            }
        }
    }
}