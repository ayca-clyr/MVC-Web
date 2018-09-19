using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161115_NorthwindManagement.Controllers
{
    public class CategoryController : Controller
    {
        northwindEntities _dbContext = new northwindEntities();
        // GET: Category
        public ActionResult Index()
        {
            //List<Category> categoryList = _dbContext.Categories.ToList();
            //var categoryList = _dbContext.Categories.ToList();
            // Çok veri var ama biz az olanı kullanacaksak, aşağıdaki kullanım daha mantıklı.
            // Burdaki list değildir. Sadece List<'a> şeklinde gözükür.
            var categoryList = _dbContext.Categories.Select(c => new Models.CategoryListItemVM()
                {
                   Id= c.CategoryID,
                   Name = c.CategoryName
                }).ToList();

            //var obj1 = new { Id = 1, Name = "" };
            //var obj2 = new { Id = 10, Name = "" };
            //var obj3 = new { PlayerId = 10, PlayerName = "" };

            //obj1 = obj2; // (Bu oluyor.)
            //obj1 = obj3;  (Bu olmuyor.)
            
               

            return View(categoryList);
        }
        // Get methodu gelirse Aşağıdaki çalışıyor.
        [HttpGet] // Action'ı HttoGet Attribute'ü ile işaretlemesen de varsayılan değer Get metodudur. Default
        // Sayfa görüntüleme gibi işlemlerde Post methodu.
        public ActionResult Edit(int id)
        {
            Category cat = _dbContext.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (cat != null)
            {
                return View(cat);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // Post methodu gelirse Aşağıdaki çalışıyor.
        // Request'in içine gömülü olarak gönderir.
        // Veritabanına gitme durumunda Post.
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            // Artık HttpPost ile Edit'de Category nesnesi almadık. Bu da demek oluyor ki bütün bilgileri okuduklarını category'e attı.

            //Category categoryToUpdate = _dbContext.Categories.SingleOrDefault
            //    (c => c.CategoryID == cat.CategoryID);

            //categoryToUpdate.CategoryName = cat.CategoryName;
            //categoryToUpdate.Description = cat.Description;

            // Elinde Id varsa Aşağıdakini kullanmak daha mantıklı. Null gelenleride yok etmiş olduk.
            _dbContext.Entry(cat).State = System.Data.Entity.EntityState.Modified;
            _dbContext.Entry(cat).Property("Picture").IsModified = false; // Buna dokunmuyor.

            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}