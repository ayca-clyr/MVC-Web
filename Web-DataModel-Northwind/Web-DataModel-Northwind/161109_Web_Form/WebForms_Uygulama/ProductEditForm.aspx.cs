using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_Uygulama.Model;

namespace WebForms_Uygulama
{
    public partial class ProductEditForm : System.Web.UI.Page
    {
        NorthwindEntities1 _dbContext;
        Product _pro;
        protected void Page_Load(object sender, EventArgs e)
        {

            _dbContext = new NorthwindEntities1();

            string ProductIdStr = Request.QueryString["id"]; //Listten Düzenle tıklanınca buraya İd yollanacak.

            //Özel Ternary if kulllanımı(null check) 
            ProductIdStr = ProductIdStr ?? "0"; //Eğer null ise 0 at değilse kendi değerini at demek
            //categoryIdStr = categoryIdStr == null ? "0" : categoryIdStr;

            int productId = int.Parse(ProductIdStr);

            //TODO : Görev ataması icin todo kullanırız.TaskList'de görünür.
            //TODO yorum satırıdır.Comments seçili olması lazım.

            if (productId == 0) //EĞER sayfaya giden Id yoksa
            {
                //YENİ KAYIT
                _pro = new Product();
            }
            else
            {
                //GÜNCELLEME
                _pro = _dbContext.Products.Find(productId);

                //Burda sadece DEBUG modda çalıştır demek bu kod ksmını
                //#if DEBUG
                //DEBUG : eğer yazılım geliştirme asamasındaysa DEBUG oluyor.
                //Release : f5 ile çalıştırılıyorsa buda Release mod oluyor.

                if (!Page.IsPostBack) //Sayfa içinde veri varsa üzerine yazma yoksa yaz demek.
                {
                    txtProductName.Text = _pro.ProductName;
                    txtUnitInStock.Text = _pro.UnitsInStock.ToString();
                    txtDiscount.Text = _pro.Discontinued.ToString();
                }
                //#endif
                btnSave.Text = "Güncelle";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // Category _cat = new Category();

            _pro.ProductName = txtProductName.Text;
            _pro.UnitsInStock =Int16.Parse(txtUnitInStock.Text);
            _pro.Discontinued =Bool.Parse(txtDiscount.Text);

            if (_pro.CategoryID == 0)
            {
                //YENİ KAYIT 
                _dbContext.Products.Add(_pro);
            }
            //else
            //{

            //}
            _dbContext.SaveChanges();
            Response.Redirect("ProductListForm.aspx"); //Kaydedince Direk Sayfaya yönlendirme
        }
    }
}