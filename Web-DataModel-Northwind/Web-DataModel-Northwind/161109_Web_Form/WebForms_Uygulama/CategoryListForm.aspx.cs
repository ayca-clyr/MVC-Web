using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_Uygulama.Model;

namespace WebForms_Uygulama
{
    public partial class CategoryListForm : System.Web.UI.Page
    {
        NorthwindEntities1 _dbContext; 
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities1();

            var allCategories = (from c in _dbContext.Categories
                                 select new
                                 {
                                     c.CategoryID,
                                     c.CategoryName,
                                     c.Description
                                 }).ToList();

            gridCategories.DataSource = allCategories;
            gridCategories.DataBind();  //Performans için DataBind yazılır

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string categoryIdStr = (sender as Button).Attributes["data-id"]; //Elementten id aldık.
           int categoryId = int.Parse(categoryIdStr);

           Category cat =_dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(cat);
            _dbContext.SaveChanges();

            //1. Sayfayı tekrardan yenilemek
            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            //2. Yada Aynı sayfaya yonlendiririz.
            Response.Redirect("CategoryListForm.aspx");

            //Web.config e  <pages enableEventValidation="false"></pages> ekliyoruz.Calışmaz yoksa.
        }
    }
}