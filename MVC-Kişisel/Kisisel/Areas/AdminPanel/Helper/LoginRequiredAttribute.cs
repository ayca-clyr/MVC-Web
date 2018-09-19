using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Helper
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                if (
                   HttpContext.Current.Request.Cookies["UserName"] != null
                   &&
                   HttpContext.Current.Request.Cookies["Password"] != null
                   )
                {
                    string userId = HttpContext.Current.Request.Cookies["UserName"].Value;
                    string password = HttpContext.Current.Request.Cookies["Password"].Value;
                    LoginHelper helper = new LoginHelper();
                    bool loginSuccessed = helper.LoginUser(userId, password, HttpContext.Current);
                    if (!loginSuccessed)
                    {
                        filterContext.Result = new RedirectResult("~/AdminPanel/Login");
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/AdminPanel/Login");
                }
            }
        }
    }
}