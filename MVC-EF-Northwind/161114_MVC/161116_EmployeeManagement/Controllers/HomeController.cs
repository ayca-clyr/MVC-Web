using _161116_EmployeeManagement.EF;
using _161116_EmployeeManagement.EF.Entities;
using _161116_EmployeeManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161116_EmployeeManagement.Controllers
{ 
   
    public class HomeController : Controller
    {
        // GET: Home
        [LoginRequired]
        public ActionResult Index()
        {
            // Home Index'i Engelledik.
            // Bunu bütün hepsine yazacağımıza Filter dosyası oluşturduk ve her Action'ada [LoginRequired] işlemi yaptık.
            //if (Session["PersonId"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            // Sorgu sırasında int,parse,convert işlemleri yapamayız. Bu yüzden üstte dönüşüm yapıyoruz ve sonradan sorguya atıyoruz.
            Employee loginEmp = new DataContext().Employees.FirstOrDefault(x => x.Id == loginEmpId);
            
            object loginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;

            return View(loginEmpName);
        }
        public ActionResult LoginUser()
        {
            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            // Sorgu sırasında int,parse,convert işlemleri yapamayız. Bu yüzden üstte dönüşüm yapıyoruz ve sonradan sorguya atıyoruz.
            Employee loginEmp = new DataContext().Employees.FirstOrDefault(x => x.Id == loginEmpId);

            //object loginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;

            return PartialView(loginEmp);

        }
    }
}