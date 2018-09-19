using _161116_EmployeeManagement.EF;
using _161116_EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _161116_EmployeeManagement.Models;
using _161116_EmployeeManagement.Filters;

namespace _161116_EmployeeManagement.Controllers
{
    /* Stateless
     * 
     * ASP.NET State Management
     * -Hidden Input [Client]  (ASP.NET,PHP,..)
     * -ViewState [Client] (webForms)
     * -Cookie [Client] (ASP.NET, PHP)
     * -SessionState [Server] (ASP.NET)
     * -ApplicationsState [Server] (ASP.NET)
    */

    // QuikWatch

    [LoginRequired]  // Bütün Hepsi için geçerli oldu. En üste koymamız.
    public class EmployeeController : Controller
    {
        // GET: Employee

        DataContext _dbContext = new DataContext();
        //public ActionResult Index()
        //{
        //    List<Employee> model = _dbContext.Employees.ToList();

        //    return View(model);
        //}
        
        public ActionResult Index()
        {
            List<EmployeeListModel> model = _dbContext.Employees
                .Select(x => new EmployeeListModel()
                {
                    // Modeldekiler --> Entity.
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    Email = x.EmailAddress,
                    DepartmentName = x.Department.Name,
                    Id = x.Id
                }).ToList();

            // Select işleminin açık hali.
            /*
            List<Employee> model2 = _dbContext.Employees.ToList();
            List<EmployeeListModel> liste = new List<EmployeeListModel>();
            foreach (var mdl in model2)
            {
                EmployeeListModel elm = new EmployeeListModel();
                elm.FirstName = mdl.FirstName;
                elm.LastName = mdl.LastName;
                elm.Salary = mdl.Salary;
                elm.Email = mdl.EmailAddress;
                elm.DepartmentName = mdl.Department.Name;
                elm.Id = mdl.Id;

                liste.Add(elm);
            }
            */

            return View(model);
        }
        public ActionResult Edit(int? id)
        {

            Employee model;  //= null;

            if (id.HasValue)
            {
                model = _dbContext.Employees.SingleOrDefault(e => e.Id == id);  // Güncelleme
            }
            else  // if() dersek yukardaki null'ı açmak zorundayız.
            {
                model = new Employee();  // Yeni Kayıt
            }


            if (model != null)
            {
                // Birini görüntülerken ona ait olanı getirirken model kullanırız.
                // Ama ben birine departman eklerken tüm hepsini getirmek gerekiyorsa ViewBag kullanırız. (Yardımcı Kayıt, Yardımcı Veri tünel.)
               
                List<Department> allDepartments = _dbContext.Departments.ToList();
                // "Id" --> DisplayMember  "Name" --> ValueMember combobox C# mantığı.
                SelectList departmentsSelectList = new SelectList(allDepartments,"Id","Name");

                //SelectList departmentsSelectList = new SelectList(_dbContext.Departments.ToList(), "Id", "Name");
                  


                // dynamic : . desen olmasada üzerinde veriyi taşıyabiliyorsun. Dinamik property oluşturur.
                /*
                ViewBag.Tsubasa = "";
                ViewBag.Muhittin = DateTime.Now;
                */

                

                ViewBag.Departments = departmentsSelectList;
                // Aynıdır ikiside. ViewData Collection gibi yazıma sahiptir.
                // ViewBag daha pratiktir. İşlem aynı sadece yazımları farklı.
                // Hatta buradan ViewData["Test"] deriz, Edit'de ViewBag.Test dersek karşılamış oluyoruz.
                
                //ViewData["Departments"] = departmentsSelectList;
                ViewData["Test"] = "Tsubasa";
               
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (emp.Id > 0)
            {
                _dbContext.Entry(emp).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Entry(emp).State = EntityState.Added;
            }

            try
            {
                // ViewBag'in ömrü 1 action kadardır. Biz burada return'da 2.ekşına gönderme yaptık. O Yüzden o message'ı göremiyoruz.
                _dbContext.SaveChanges();
                //ViewBag.ResultMessage = "Kaydetme işlemi Başarılı";
                TempData["ResultMessage"] = "Kaydetme işlemi Başarılı";
                TempData["Test"] = "Hala burada mısın?";
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id.HasValue)
            {

                Employee emp = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

                return View(emp);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee empSil = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (empSil != null)
            {

                _dbContext.Employees.Remove(empSil);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
       
    }
}