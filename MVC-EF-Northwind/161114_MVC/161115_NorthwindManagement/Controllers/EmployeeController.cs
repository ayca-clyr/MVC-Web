using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _161115_NorthwindManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public northwindEntities _dbContext;
        public EmployeeController()
        {
            _dbContext = new northwindEntities();
        }
        public ActionResult Index()
        {
            var employeeList = _dbContext.Employees.ToList();
            return View(employeeList);
        }
        /// <summary>
        /// Çalışan eklemek için gerekli olan ekleme formunu içeren View'ı çağırır.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddForm()
        {
            return View();
        }

        /// <summary>
        /// Çalışan ekleme View'ından gelen dataları yeni çalışan nesnesinde biriktirip database'e kaydeder ve sonrasında listeleme sayfasının Action'ına yönlendirir
        /// </summary>
        /// <param name="firstName">Ad</param>
        /// <param name="lastName">Soyad</param>
        /// <param name="title">Ünvan</param>
        /// <param name="city">Şehir</param>
        /// <returns></returns>
        public ActionResult Add(string firstName, string lastName, string title, string city)
        {
            
            Employee newEmp = new Employee();

            // İsimler Aynı olmaz zorunda.
            //newEmp.FirstName = Request.Form["firstName"];
            newEmp.FirstName = firstName;
            newEmp.LastName = lastName;
            newEmp.Title = title;
            newEmp.City = city;

            _dbContext.Employees.Add(newEmp);
            _dbContext.SaveChanges();

            // 1. Yöntem  ( Bu View Adı ve içine girmez methodun. Değişiklikleri görmez.)
            //return View("Index", _dbContext.Employees.ToList());

            // 2. Yöntem ( Bu Tamamen methodu çağırdığı için en güvenilir yöntem.)
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Parametre olarak gelen Id'ye sahip çalışanı databaseden siler ve çalışan listesini barındıran Action'a yönlendirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Employee emp = _dbContext.Employees.Find(id);

            _dbContext.Employees.Remove(emp);
            //_dbContext.Entry(emp).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        ///  Çalışan güncellemek için gerekli olan ekleme formunu içeren View'ı çağırır. İlgili çalışanın datası da model olarak view'a gider.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateForm(int id)
        {
            Employee emp = _dbContext.Employees.Find(id);

            return View(emp);
        }
        [HttpPost]
        public ActionResult Update(int id,string firstName, string lastName, string title, string city)
        {

            Employee emp = _dbContext.Employees.Find(id);
           
            emp.FirstName = firstName;
            emp.LastName = lastName;
            emp.Title = title;
            emp.City = city;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}