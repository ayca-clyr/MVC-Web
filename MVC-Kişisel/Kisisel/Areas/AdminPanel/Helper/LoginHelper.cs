using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kisisel.Areas.AdminPanel.Helper
{
    public class LoginHelper
    {
        UserBLL _userBLL = new UserBLL();
        public bool LoginUser(string username, string password, HttpContext httpContext)
        {
            User user = _userBLL.LoginUser(username, password);
            if (user != null)
            {
                httpContext.Session["User"] = user;
                httpContext.Session.Timeout = 150;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}