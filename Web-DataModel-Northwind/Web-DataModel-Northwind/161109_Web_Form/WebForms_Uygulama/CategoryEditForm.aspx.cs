using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_Uygulama.Model;

namespace WebForms_Uygulama
{
    public partial class CategoryEditForm : System.Web.UI.Page
    {
        NorthwindEntities1 _dbContext;
        Category _cat;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities1();

            string categoryIdStr = Request.QueryString["id"]; //Listten Düzenle tıklanınca buraya İd yollanacak.

            //Özel Ternary if kulllanımı(null check) 
            categoryIdStr = categoryIdStr ?? "0"; //Eğer null ise 0 at değilse kendi değerini at demek
            //categoryIdStr = categoryIdStr == null ? "0" : categoryIdStr;

            int categoryId = int.Parse(categoryIdStr);

            //TODO : Görev ataması icin todo kullanırız.TaskList'de görünür.
            //TODO yorum satırıdır.Comments seçili olması lazım.

            if (categoryId == 0) //EĞER sayfaya giden Id yoksa
            {
                //YENİ KAYIT
                _cat = new Category();
            }
            else
            {
                //GÜNCELLEME
                _cat = _dbContext.Categories.Find(categoryId);

                //Burda sadece DEBUG modda çalıştır demek bu kod ksmını
//#if DEBUG
                //DEBUG : eğer yazılım geliştirme asamasındaysa DEBUG oluyor.
                //Release : f5 ile çalıştırılıyorsa buda Release mod oluyor.

                if (!Page.IsPostBack) //Sayfa içinde veri varsa üzerine yazma yoksa yaz demek.
                {
                    txtCategoryName.Text = _cat.CategoryName;
                    txtDescription.Text = _cat.Description;
                }
//#endif
                btnSave.Text = "Güncelle";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Category _cat = new Category();

            _cat.CategoryName = txtCategoryName.Text;
            _cat.Description = txtDescription.Text;

            if (_cat.CategoryID == 0)
            {
                //YENİ KAYIT 
                _dbContext.Categories.Add(_cat);
            }
            //else
            //{

            //}
            _dbContext.SaveChanges();
            Response.Redirect("CategoryListForm.aspx"); //Kaydedince Direk Sayfaya yönlendirme
        }
    }
}