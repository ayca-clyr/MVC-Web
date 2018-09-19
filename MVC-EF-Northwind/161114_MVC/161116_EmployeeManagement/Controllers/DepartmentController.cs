using _161116_EmployeeManagement.EF;
using _161116_EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _161116_EmployeeManagement.Filters;

namespace _161116_EmployeeManagement.Controllers
{
    [LoginRequired]
    public class DepartmentController : Controller
    {
        DataContext _dbContext = new DataContext();
        // GET: Department
        
        public ActionResult Index()
        {
            List<Department> model = _dbContext.Departments.ToList();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            Department model;
            
            if(id.HasValue){
                model = _dbContext.Departments.SingleOrDefault(d => d.Id == id);  // Güncelleme
            }
            else
            {
                model = new Department();  // Yeni Kayıt
            }
            
            
            if (model != null)           
                return View(model);
            else          
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (department.Id != 0) {
            _dbContext.Entry(department).State = EntityState.Modified;
           
            
            }
            else
            {

                _dbContext.Entry(department).State = EntityState.Added;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {

            if (id.HasValue)
            {

                Department department = _dbContext.Departments.FirstOrDefault(x => x.Id == id);

                return View(department);
            }
            else
            {
                return HttpNotFound();
            }
        }
         
        [HttpPost]
        public ActionResult Delete(int id)
        {
             Department departmentSil = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
            if (departmentSil != null)
            {
                
                _dbContext.Departments.Remove(departmentSil);
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