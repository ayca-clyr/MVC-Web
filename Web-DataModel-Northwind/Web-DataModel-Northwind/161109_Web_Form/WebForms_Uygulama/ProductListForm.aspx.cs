using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_Uygulama.Model;

namespace WebForms_Uygulama
{
    public partial class ProductListForm : System.Web.UI.Page
    {
        NorthwindEntities1 _dbContext;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities1();

             var allProduct = (from p in _dbContext.Products
                                 select new
                                 {
                                  p.ProductID,
                                  p.ProductName,
                                p.UnitsInStock,
                                p.Discontinued
                                 }).ToList();

            gridProduct.DataSource = allProduct;
            gridProduct.DataBind();  //Performans için DataBind yazılır

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ProductIdStr = (sender as Button).Attributes["data-id"]; //Elementten id aldık.
            int productId = int.Parse(ProductIdStr);

            Product pro = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(pro);
            _dbContext.SaveChanges();

            //1. Sayfayı tekrardan yenilemek
            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            //2. Yada Aynı sayfaya yonlendiririz.
            Response.Redirect("ProductListForm.aspx");

            //Web.config e  <pages enableEventValidation="false"></pages> ekliyoruz.Calışmaz yoksa.
        }
        }
    }
