using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _161109_WebForms_Intro
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Adım 1 :
            //int random = new Random().Next(10);
            //result.InnerText = random.ToString();

            // Adım 6 (Part 1)

            if (!Page.IsPostBack)  // Eğer sayfa ilk açılıyorsa ya da url'den talep edildiyse o zaman yükle. Ama eğer 2.kez çağırlıyorsa o zaman yükleme. Çünkü içinde zaten değerler vardır.
            FillCategories(categoryList);

        }

      


        // Adım 4 (Part 1) :
        public int rndCount = 0;


        public void btnRunClick(object sender, EventArgs e){
            // Adım 2 :
            /*
            int random = new Random().Next(10);
            result.InnerText = random.ToString();
            */
            // Adım 3 :
            /*
            string firstNumberStr = firstNumber.Value;
            string secondNumberStr = secondNumber.Value;

            int fNum = int.Parse(firstNumberStr);
            int sNum = int.Parse(secondNumberStr);

            // Aşağıdaki Ternay If olmasaydı aşağıdaki uzun yolu seçerek yapacaktık.
            //int kücük = 0;   fNum > sNum ? sNum : fNum
            //int buyuk = 0;   fNum > sNum ? sNum : fNum

            // Aşağıdaki Turn
            //if(fNum > sNum){
            //    buyuk=fNum;
            //    kücük=sNum;
            //}
            //else{
            //    kücük=fNum;
            //    buyuk=sNum;
            //}
            //new Random().Next(kücük,buyuk);

            int random = new Random().Next
                (fNum > sNum ? sNum : fNum,     // Küçük sayıyı bulan Ternary If
                fNum > sNum ? fNum : sNum);     // Büyük sayıyı bulan Ternary If

            result.InnerText = random.ToString();
            // int random1 = new Random().Next(int.Parse(firstNumber.Value), int.Parse(secondNumber.Value));
            */

            // Adım 4 (Part 2)
            /*
            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);

            int random = new Random().Next
              (fNum > sNum ? sNum : fNum,     // Küçük sayıyı bulan Ternary If
              fNum > sNum ? fNum : sNum);     // Büyük sayıyı bulan Ternary If
            
            newResult.InnerText = random.ToString();                        
            rndCount++;
            count.InnerText = rndCount.ToString();
              */

            // Adım 5:
           /*
            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);

            string productListHTML = GetProductsHTML(
                  fNum > sNum ? sNum : fNum,
                  fNum > sNum ? fNum : sNum);

            result.InnerHtml = productListHTML;
           */

            // Adım 6:
            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);
            string categoryName = categoryList.Items[categoryList.SelectedIndex].Value;
            string productListHTML = GetProductsHTMLWithCategory(
                  fNum > sNum ? sNum : fNum,
                  fNum > sNum ? fNum : sNum,
                  categoryName);

            result.InnerHtml = productListHTML;

        }

       

        // 3 tane slash koyarsan <summary> gelir. Bu açıklama kısmıdır. Methoda gelincede bu açıklamayı görüyoruz. (CTRL + SHIFT + BOSLUK)
        /// <summary>          
        /// Adım 5 : This method returns Northwind products which has enough stock
        /// </summary>
        /// <param name="small">Min Stock Count</param>
        /// <param name="large">Max Stock Count</param>
        /// <returns></returns>
        private string GetProductsHTML(int small, int large)
        {
            string htmlString = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=northwind;integrated security=sspi";  // Buraya server=.; yazmasakta olur. Default olarak bağlandığı için sıkıntı çıkarmıyor.

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
                                SELECT ProductName, UnitsInStock FROM Products
                                WHERE UnitsInStock BETWEEN @p1 AND @p2" ;

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);
            //string deger = "sdssdd";    // Enter'a basınca alt satıra geçiyor, böylece o değer " dan ayrıymış gibi gözüküyor. Biz bunu engellemek için başına @ koyuyoruz. İki tırnak arasında herşeyi metinsel olarak görüyor. (Enter'a bassak bile)
            
            // Alışılmış try-catch blockları yazılabilir aöa;
            // devam

            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                // Çektiğimiz verileri alt alta yazdırmak istiyoruz.
                htmlString += string.Format("{0} ({1}) <br />", rdr.GetString(0), rdr.GetInt16(1).ToString());   // 1. kolon string, 2.kolon small'dır. Bu yüzden Int16.
            }


            cmd.Connection.Close();
            return htmlString;
        }

        /// <summary>
        /// Adım 6 : Fills a select with Nothwind Categories
        /// </summary>
        /// <param name="selectElement">A Select Element</param>

        private void FillCategories(HtmlSelect selectElement)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "database=northwind;integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT CategoryName FROm Categories";
            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                // Gelen select elementin option eklediğimiz yer :
                selectElement.Items.Add(rdr.GetString(0));
            }
            cmd.Connection.Close();
        }
        /// <summary>
        /// Adım 6 : This method returns Northwind products which has enough stock with specific Category
        /// </summary>
        /// <param name="small">Min Stock Count</param>
        /// <param name="large">Max Stock Count</param>
        /// <param name="categoryName">Category Name</param>
        /// <returns></returns>
        private string GetProductsHTMLWithCategory(int small, int large, string categoryName)
        {
            string htmlString = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=northwind;integrated security=sspi";  // Buraya server=.; yazmasakta olur. Default olarak bağlandığı için sıkıntı çıkarmıyor.

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
                                SELECT ProductName, UnitsInStock,CategoryName FROM Products p
                                JOIN Categories c ON p.CategoryId = c.CategoryId
                                WHERE 
                                    CategoryName = @categoryName
                                AND 
                                UnitsInStock BETWEEN @p1 AND @p2";

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            //string deger = "sdssdd";    // Enter'a basınca alt satıra geçiyor, böylece o değer " dan ayrıymış gibi gözüküyor. Biz bunu engellemek için başına @ koyuyoruz. İki tırnak arasında herşeyi metinsel olarak görüyor. (Enter'a bassak bile)

            // Alışılmış try-catch blockları yazılabilir aöa;
            // devam

            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                // Çektiğimiz verileri alt alta yazdırmak istiyoruz.
                // Burada yazdığımız parantez dışındaki --> () görüntü açısından yazıldı. String veya Int olmasıyla alakalı değil!
                htmlString += string.Format("{0} ({1}) ({2}) <br />"
                    , rdr.GetString(0)               // ProductName  (string)
                    , rdr.GetInt16(1).ToString()     // UnitsInStock  (small=Int16)
                    ,rdr.GetString(2));              //CategoryName (string)
            }

            cmd.Connection.Close();
            return htmlString;

        }
    }
}