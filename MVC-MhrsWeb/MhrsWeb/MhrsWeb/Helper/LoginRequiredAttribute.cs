using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Helper
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["CurrentUserTC"] == null)
            {
                if (
                   HttpContext.Current.Request.Cookies["CurrentTC"] != null
                   &&
                   HttpContext.Current.Request.Cookies["CurrentPassword"] != null
                   )
                {
                    string tc = HttpContext.Current.Request.Cookies["CurrentTC"].Value;
                    string password = HttpContext.Current.Request.Cookies["CurrentPassword"].Value;
                    LoginHelper helper = new LoginHelper();
                    bool loginSuccessed = helper.LoginUser(tc, password, "on", HttpContext.Current);
                    if (!loginSuccessed)
                    {
                        filterContext.Result = new RedirectResult("~/Login", true);
                    }

                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login", true);
                }
            }
        }
    }
}