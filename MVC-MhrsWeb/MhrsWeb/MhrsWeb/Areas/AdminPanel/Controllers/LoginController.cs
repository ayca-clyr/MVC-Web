using MhrsWeb.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        MhrsWeb.Helper.Md5Service md5Service = new MhrsWeb.Helper.Md5Service();
        // GET: AdminPanel/Login
        public ActionResult Index()
        {
            if ((Request.Cookies["TC"] != null && Request.Cookies["Password"] != null) || Session["User"] != null)
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
                return Content("<script language='javascript' type='text/javascript'>alert('KullanıcıAdı ve Şifre Kombinasyonu HATALI!!! veya Giriş Yetkiniz YOK!!!');window.location = '/AdminPanel/Login';</script>");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserTC"] = null;

            Response.Cookies["TC"].Expires = DateTime.Now.AddMilliseconds(-100);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMilliseconds(-100);

            return RedirectToAction("Index");
        }

        public ActionResult SifremiUnuttum()
        {
            return View(new Login());
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(Kullanici kullanici)
        {
            MhrsWeb.Helper.EmailService emailService = new MhrsWeb.Helper.EmailService();
            MhrsWeb.Helper.enums.MailSendStatus result = emailService.SendMail(kullanici);

            if (result == MhrsWeb.Helper.enums.MailSendStatus.BASARILI)
                return Content("<script language='javascript' type='text/javascript'>alert('Yeni Şifreniz E-Mailinize Gönderilmiştir!');window.location = '/AdminPanel/Login/Index';</script>");

            if (result == MhrsWeb.Helper.enums.MailSendStatus.BASARISIZ)
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz! ');window.location = '/AdminPanel/Login/Index';</script>");

            return Content("<script language='javascript' type='text/javascript'>alert('Sistem Kayıtlı Mail Bulunuamadı!');window.location = '/AdminPanel/Login/Index';</script>");
        }
    }
}