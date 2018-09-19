using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminPanel/Login
        public ActionResult Index()
        {
            if ((Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null) || Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            bool result = new LoginHelper().LoginUser(user.UserName, user.Password, System.Web.HttpContext.Current);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('KullanıcıAdı ve Şifre Kombinasyonu HATALI !!!');window.location = '/AdminPanel/Login';</script>");
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Response.Cookies["UserName"].Expires = DateTime.Now.AddMilliseconds(-100);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMilliseconds(-100);
            return RedirectToAction("Index");
        }
    }
}