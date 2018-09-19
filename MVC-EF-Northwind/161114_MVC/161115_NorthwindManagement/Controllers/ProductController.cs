using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _161115_NorthwindManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
         public northwindEntities _dbContext;
       public ProductController ()
	{
            _dbContext = new northwindEntities();
	}

    
        public ActionResult Index()
        {
            var productList = _dbContext.Products.ToList();
            return View(productList);
        }
        public ActionResult AddForm()
        {
            return View();
        }
        public ActionResult Add(string productName, Int16 unitsInStock, bool discontinued)
        {
            Product newPro = new Product();
            newPro.ProductName = productName;       
            newPro.UnitsInStock = unitsInStock;
            newPro.Discontinued = discontinued;

            _dbContext.Products.Add(newPro);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Product pro = _dbContext.Products.Find(id);

            //_dbContext.Employees.Remove(emp);
            _dbContext.Entry(pro).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UpdateForm(int id)
        {
            Product pro = _dbContext.Products.Find(id);

            return View(pro);
        }

        public ActionResult Update(int id, string productName, Int16 unitsInStock, bool discontinued)
        {
            Product pro = _dbContext.Products.Find(id);

            pro.ProductName = productName;
            pro.UnitsInStock = unitsInStock;
            pro.Discontinued = discontinued;

            return RedirectToAction("Index");
        }
    }
}