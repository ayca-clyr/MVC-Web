using MhrsWeb.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Areas.AdminPanel.Helper
{
    public class LoginHelper
    {
        MhrsWebDBEntities _db = new MhrsWebDBEntities();
        public bool LoginUser(string tc, string password, string RememberMe, HttpContext httpContext)
        {
            Login user = new Login();
            Login tempUser = _db.Login.Where(x => x.TC == tc && x.Password == password).FirstOrDefault();
            if (tempUser != null)
            {
                int? kulaniciYetkiId = _db.Kullanici.Where(x => x.TC == tempUser.TC).Select(x => x.CommandId).FirstOrDefault();
                int? adminId = _db.Command.Where(x => x.Name == "Admin").Select(x => x.Id).FirstOrDefault();
                if (kulaniciYetkiId == adminId)
                    user = tempUser;
            }

            if (user.TC != null)
            {
                httpContext.Session.Timeout = 150;
                httpContext.Session["User"] = user;
                httpContext.Session["UserTC"] = user.TC;

                if (!string.IsNullOrEmpty(RememberMe) && RememberMe == "on")
                {
                    httpContext.Response.Cookies["TC"].Value = tc;
                    httpContext.Response.Cookies["TC"].Expires = DateTime.Now.AddYears(1);

                    httpContext.Response.Cookies["Password"].Value = password;
                    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}