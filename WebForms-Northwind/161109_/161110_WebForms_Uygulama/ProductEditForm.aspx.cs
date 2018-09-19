using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class ProductEditForm : System.Web.UI.Page
    {
        northwindEntities _dbContext;
        Product _pro;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new northwindEntities();


            string productIdStr = Request.QueryString["id"];  //?id dediğimiz kısım.

            
            productIdStr = productIdStr ?? "0"; 

            int productId = int.Parse(productIdStr);


            if (productId == 0)
            {
                // Yeni Kayıt
                _pro = new Product();
            }
            else
            {
                // Güncelle
                _pro = _dbContext.Products.Find(productId);
            


                if (!Page.IsPostBack)
                {

                   txtBxProductName.Text = _pro.ProductName;
                   txtBxProductUnitInStock.Text = _pro.UnitsInStock.ToString();
                  
                        cBxProductDiscontinued1.Checked = _pro.Discontinued;
                  
               
                  
                }

                btnSave.Text = "Güncelle";

            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _pro.ProductName = txtBxProductName.Text;
            _pro.UnitsInStock = Int16.Parse(txtBxProductUnitInStock.Text);
          
                _pro.Discontinued = cBxProductDiscontinued1.Checked;          

            if (_pro.ProductID == 0)
            {


                _dbContext.Products.Add(_pro);
            }


            _dbContext.SaveChanges();

            Response.Redirect("ProductListForm.aspx");   // Sayfa yönlendirme

        }
    }
}