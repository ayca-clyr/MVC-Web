using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class image : System.Web.UI.Page
    {
        // img src'e Request atıyoruz. Oraya Id çekiyoruz ve o ID'ye ait resmi burdan çekiyoruz.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                byte[] imageData = new northwindEntities().Employees
                    .Find(int.Parse(Request.QueryString["id"]))
                    .Photo;

                if (imageData == null)  // Şuan image Ram'de.
                    return;

                //MemoryStream stream = new MemoryStream(imageData, 78, imageData.Length - 78);
                // Şu indexten al şu kadar al diyebilirizde.

                MemoryStream stream = new MemoryStream(imageData.Skip(78).ToArray()); 
                // 78'ini geç Sonrasını ArrayListele.
                // Data Yüklenene kadar Memory açık kalsın. 
                // MemoryStream = Bellek Akışı demek.   
                
                stream.WriteTo(Response.OutputStream); // Bu memory akışını sayfanın cevabı olarak ver.
            }
        }
    }
}