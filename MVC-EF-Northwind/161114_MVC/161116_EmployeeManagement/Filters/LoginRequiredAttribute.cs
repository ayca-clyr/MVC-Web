using _161116_EmployeeManagement.Controllers;
using _161116_EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161116_EmployeeManagement.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        // ActionExecuted  --> Çalıştıktan sonra
        // ActionExecuting --> Çalışıyorken
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["PersonId"] == null)
            {
                if (HttpContext.Current.Request.Cookies["UserId"] != null
                    && HttpContext.Current.Request.Cookies["Password"] != null)
                {
                    string userId = HttpContext.Current.Request.Cookies["UserId"].Value;
                    string password = HttpContext.Current.Request.Cookies["Password"].Value;

                    /* Yanlış Yöntem. Çünkü Session atarken null getiriyor. Yeni instance aldığımız için null getiriyor. */
                    //LoginController loginController = new LoginController();
                    //loginController.Index(userId, password, "on");

                    /* İşe Yaramadı! */
                    //HttpContext.Current.Response.RedirectToRoute(
                    //    new
                    //    {
                    //        controller = "Login",
                    //        action = "Index",
                    //        userId = userId,
                    //        password = password,
                    //        rememberMe = "on"
                    //    });

                    LoginHelper helper = new LoginHelper();
                    helper.LoginUser(userId, password, "on", HttpContext.Current.Session, HttpContext.Current.Response);
                }
                else
                {

                    //filterContext.HttpContext.Response.RedirectToRoute("~/Login");
                    filterContext.HttpContext.Response.RedirectPermanent("~/Login");
                    //filterContext.HttpContext.Response.Redirect("~/Login"); 
                }
            }
        }
    }
}