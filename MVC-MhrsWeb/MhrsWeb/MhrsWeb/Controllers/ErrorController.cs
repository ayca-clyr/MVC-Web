using MhrsWeb.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}