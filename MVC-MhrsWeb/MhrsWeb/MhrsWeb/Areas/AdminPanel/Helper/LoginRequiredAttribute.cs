using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel.Helper
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserTC"] == null)
            {
                if (
                   HttpContext.Current.Request.Cookies["TC"] != null
                   &&
                   HttpContext.Current.Request.Cookies["Password"] != null
                   )
                {
                    string tc = HttpContext.Current.Request.Cookies["TC"].Value;
                    string password = HttpContext.Current.Request.Cookies["Password"].Value;
                    LoginHelper helper = new LoginHelper();
                    bool loginSuccessed = helper.LoginUser(tc, password, "on", HttpContext.Current);
                    if (!loginSuccessed)
                    {
                        filterContext.Result = new RedirectResult("~/AdminPanel/Login", true);
                    }

                }
                else
                {
                    filterContext.Result = new RedirectResult("~/AdminPanel/Login", true);
                }
            }
        }
    }

}