using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class ProductListForm : System.Web.UI.Page
    {
        northwindEntities _dbContext;
        protected void Page_Load(object sender, EventArgs e)
        
        {
            _dbContext = new northwindEntities();
           
            // 2. Yöntem
            Rap.DataSource = new northwindEntities().Products
        .Select(x => new
        {
            x.ProductID,
            x.ProductName,
            x.UnitPrice,
            x.UnitsInStock,
            x.Category.CategoryName
        }).ToList();
        
        Rap.DataBind();



            
            //var allProducts = (from p in _dbContext.Products
            //                   select new
            //                   {
            //                       p.ProductID,
            //                       p.ProductName,
            //                       p.UnitsInStock,
            //                       p.Discontinued
            //                   }).ToList();
            //gridProduct.DataSource = allProducts;
            //gridProduct.DataBind();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string productIdStr = (sender as Button).Attributes["data-id"];
            int productId = int.Parse(productIdStr);

            Product pro = _dbContext.Products.Find(productId);

            _dbContext.Products.Remove(pro);
            _dbContext.SaveChanges();

 
            Response.Redirect("ProductListForm.aspx");
            
        }
    }
}