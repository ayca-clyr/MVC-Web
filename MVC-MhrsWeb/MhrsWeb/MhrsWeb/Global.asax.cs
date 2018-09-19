using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MhrsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    HttpException httpException = exception as HttpException;

        //    var _errorCode = httpException.GetHttpCode();
        //    if (_errorCode == 400 || _errorCode == 404 || _errorCode == 500)
        //    {

        //        //YONLENDIRME OGRENILECEK

        //    }

        //}
    }
}
