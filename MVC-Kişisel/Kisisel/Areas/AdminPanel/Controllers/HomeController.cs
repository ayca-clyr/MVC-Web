using BusinessLayer;
using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {
        UserBLL _userBLL = new UserBLL();
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string Password, string NewPassword, string NewPassword2)
        {
            if (((User)Session["User"]).Password == Password)
            {
                if (NewPassword == NewPassword2)
                {
                    if (!string.IsNullOrWhiteSpace(NewPassword) && !string.IsNullOrWhiteSpace(NewPassword))
                    {
                        User user = ((User)Session["User"]);
                        user.Password = NewPassword;
                        Session["User"] = user;
                        _userBLL.Update(user);

                        return Content("<script language='javascript' type='text/javascript'>alert('ŞİFRE DEĞİŞTİRİLDİ');window.location = '/AdminPanel/Home';</script>");
                    }
                    else
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('\"Yeni Şifre\" alanları boş bırakılamaz !!');window.location = '/AdminPanel/Home/ChangePassword';</script>");
                    }
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Girdiğiniz \"Yeni Şifre\" alanlar aynı değil !!');window.location = '/AdminPanel/Home/ChangePassword';</script>");
                }
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Eski şifreyi hatalı girdiniz !!');window.location = '/AdminPanel/Home/ChangePassword';</script>");
            }


        }
    }
}