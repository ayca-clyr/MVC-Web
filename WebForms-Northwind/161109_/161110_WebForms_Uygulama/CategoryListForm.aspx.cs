using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class CategoryListForm : System.Web.UI.Page
    {
        northwindEntities _dbContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new northwindEntities();
            var allCategories = (from c in _dbContext.Categories
                                 select new
                                 {
                                     c.CategoryID,
                                     c.CategoryName,
                                     c.Description
                                 }).ToList();

            gridCategories.DataSource = allCategories;
            gridCategories.DataBind();      // Performans.

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string categoryIdStr = (sender as Button).Attributes["data-id"];
            int categoryId = int.Parse(categoryIdStr);

            Category cat = _dbContext.Categories.Find(categoryId);
            
            _dbContext.Categories.Remove(cat);
            _dbContext.SaveChanges();

            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            Response.Redirect("CategoryListForm.aspx");

            //<pages enableEventValidation="false"></pages>
            // Çakışmaması için false yapıyoruz. Bunu Web Config'e yaz. <<system.web'in üstüne.>>

        }
    }
}