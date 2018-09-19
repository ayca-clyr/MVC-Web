using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Helper
{
    public class LoginHelper
    {
        MhrsWebDBEntities _db = new MhrsWebDBEntities();

        public bool LoginUser(string tc, string password, string RememberMe, HttpContext httpContext)
        {
            Login user = _db.Login.Where(x => x.TC == tc && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                httpContext.Session.Timeout = 150;
                httpContext.Session["CurrentUser"] = user;
                httpContext.Session["CurrentUserTC"] = user.TC;

                if (!string.IsNullOrEmpty(RememberMe) && RememberMe == "on")
                {
                    httpContext.Response.Cookies["CurrentTC"].Value = tc;
                    httpContext.Response.Cookies["CurrentTC"].Expires = DateTime.Now.AddYears(1);

                    httpContext.Response.Cookies["CurrentPassword"].Value = password;
                    httpContext.Response.Cookies["CurrentPassword"].Expires = DateTime.Now.AddYears(1);
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