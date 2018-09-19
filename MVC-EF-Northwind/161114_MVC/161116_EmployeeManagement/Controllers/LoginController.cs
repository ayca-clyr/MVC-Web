using _161116_EmployeeManagement.EF;
using _161116_EmployeeManagement.EF.Entities;
using _161116_EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161116_EmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string userId, string password,string rememberMe)
        {
            LoginHelper helper = new LoginHelper();
            bool loginSuccess = helper.LoginUser(userId, password, rememberMe, Session, Response);


            if (loginSuccess)
            {
                 return RedirectToAction("Index","Home");
              
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre kombinasyonu hatalı!";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session["PersonId"] = null;
            return RedirectToAction("Index");
        }

       
    }
}