using MhrsWeb.Helper;
using MhrsWeb.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Controllers
{
    public class LoginController : Controller
    {
        Md5Service md5Service = new Md5Service();
        // GET: Login
        public ActionResult Index()
        {
            if ((Request.Cookies["CurrentTC"] != null && Request.Cookies["CurrentPassword"] != null) || Session["CurrentUser"] != null)
                return RedirectToAction("Index", "Home");
          
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login user, string RememberMe)
        {

            string passwordMd5 = md5Service.Md5Sifre(user.Password);
            bool result = new LoginHelper().LoginUser(user.TC, passwordMd5, RememberMe, System.Web.HttpContext.Current);
            if (result)
                return RedirectToAction("Index", "Home");
            else
                return Content("<script language='javascript' type='text/javascript'>alert('KullanıcıAdı ve Şifre Kombinasyonu HATALI !!!');window.location = '/Login';</script>");
        }
        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            Session["CurrentUserTC"] = null;

            Response.Cookies["CurrentTC"].Expires = DateTime.Now.AddMilliseconds(-100);
            Response.Cookies["CurrentPassword"].Expires = DateTime.Now.AddMilliseconds(-100);

            Session["LoginFullName"] = null;

            return RedirectToAction("Index");
        }
        public ActionResult Kaydol()
        {
            return View(new Kullanici());
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanici kullanici, string sifre, string sifreTekrar, int cinsiyetId)
        {



            if (!ModelState.IsValid)
                return View();

    

            if (kullanici.DateOfBirth == null || (string.IsNullOrWhiteSpace(kullanici.DateOfBirth.ToString())))
                return Content("<script language='javascript' type='text/javascript'>alert('Doğum tarihi formatı hatalı!');window.location = '/Login/Kaydol';</script>");

            if (sifre != sifreTekrar)
                return Content("<script language='javascript' type='text/javascript'>alert('Şifre ve Şifre(TEKRAR) alanları aynı olmak zorunda!');window.location = '/Login/Kaydol';</script>");


            MhrsWebDBEntities db = new MhrsWebDBEntities();
            Login loginKontrol = db.Login.Where(x => x.TC == kullanici.TC).FirstOrDefault();
            Kullanici kullaniciKontrol = db.Kullanici.Where(x => x.Email == kullanici.Email).FirstOrDefault();
            if (loginKontrol != null)
                return Content("<script language='javascript' type='text/javascript'>alert('Sistemde kayıtlı böyle bir TC zaten var !!!');window.location = '/Login/Kaydol';</script>");

            if (kullaniciKontrol != null)
                return Content("<script language='javascript' type='text/javascript'>alert('Sistemde kayıtlı böyle bir Email zaten var !!!');window.location = '/Login/Kaydol';</script>");

            try
            {
                kullanici.CinsiyetId = cinsiyetId;
                kullanici.CommandId = 3; //(3 = Hasta)
                db.Kullanici.Add(kullanici);
                db.SaveChanges();

                Login newLogin = new Login();
                newLogin.TC = kullanici.TC;
                Md5Service md5Sifre = new Md5Service();
                newLogin.Password = md5Sifre.Md5Sifre(sifre);
                newLogin.Durum = false;

                db.Login.Add(newLogin);
                db.SaveChanges();

                return Content("<script language='javascript' type='text/javascript'>alert('Kayıt işlemi başarıyla gerçekleşti !!!');window.location = '/Login/Index';</script>");
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Kayıt yapılamadı.Bir hata meydana geldi !!!');window.location = '/Login/Kaydol';</script>");
            }

        }
        public ActionResult SifremiUnuttum()
        {
            return View(new Login());
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(Kullanici kullanici)
        {


            EmailService emailService = new EmailService();
            MailSendStatus result = emailService.SendMail(kullanici);



            if (result == MailSendStatus.BASARILI)
                return Content("<script language='javascript' type='text/javascript'>alert('Yeni Şifreniz E-Mailinize Gönderilmiştir!');window.location = '/Login/Index';</script>");

            if (result == MailSendStatus.BASARISIZ)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz! ');window.location = '/Login/Index';</script>");


            return Content("<script language='javascript' type='text/javascript'>alert('Sistem Kayıtlı Mail Bulunuamadı!');window.location = '/Login/Index';</script>");


        }
    }
}