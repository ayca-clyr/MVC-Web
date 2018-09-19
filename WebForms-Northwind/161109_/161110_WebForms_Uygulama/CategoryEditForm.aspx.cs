using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class CategoryEditForm : System.Web.UI.Page
    {
        northwindEntities _dbContext;
        Category _cat;
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Görev ataması için todo kullanırız. TaskList'de görünür.
            // Bu bir yorum satırıdır. Düzgün yaz. View'den TaskList seç, oradan da Comments'i seç. Direk oraya gider.

            _dbContext = new northwindEntities();

            string categoryIdStr = Request.QueryString["id"];  //?id dediğimiz kısım.

            // Özel Ternary if kullanımı. (null check)
            // id'den 0 gelme olasılığı yok güncellede. Fakat Yeni Kayıttada aynı sayfaya gittiği için ordan 0 gelebilir. O yüzden kontrol yapıyoruz.
            categoryIdStr = categoryIdStr ?? "0";  // Bunu at ama nullsa 0 at.
            //string deger = categoryIdStr == null ? "0" : categoryIdStr;  // Null'sa 0 at. Değilse değeri at.

            int categoryId = int.Parse(categoryIdStr);


            if (categoryId == 0)
            {
                // Yeni Kayıt
                _cat = new Category();
            }
            else
            {
                // Güncelle
                _cat = _dbContext.Categories.Find(categoryId);
// Eğer yazılım geliştirme aşamasındaysan biz buna DEBUG koyarız. Ve bu kod çalışır.(Test). RELEASE ise;
// Proje geliştirme aşamasından çıktı yayında demek. Buda kodu çalıştırmaz. Yani Debug'lara düşmez.
 

                if (!Page.IsPostBack)
                {

                    txtBxCategoryName.Text = _cat.CategoryName;
                    txtBxCategoryDescription.Text = _cat.Description;

                }
        
                btnSave.Text = "Güncelle";

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Category cat = new Category();

            _cat.CategoryName = txtBxCategoryName.Text;
            _cat.Description = txtBxCategoryDescription.Text;

            if (_cat.CategoryID == 0)
            {


                _dbContext.Categories.Add(_cat);
            }


            _dbContext.SaveChanges();

            Response.Redirect("CategoryListForm.aspx");   // Sayfa yönlendirme


        }
    }
}