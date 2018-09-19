using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161109_WebForms_Intro
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var value = Button2.Text;
            var value2 = Button_html.InnerText;
            var value3 = Button_input.Value;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}