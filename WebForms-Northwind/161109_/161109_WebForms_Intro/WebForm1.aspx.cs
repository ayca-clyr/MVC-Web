using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace _161109_WebForms_Intro
{
    // c# kısmı
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Attributes.Add("osman", "değer");  // Kaydet-build et- çalıştır. Yoksa değişiklikler görünmez.
        }
    }
}