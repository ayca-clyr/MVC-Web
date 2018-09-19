<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_161109_WebForms_Intro.WebForm1" %>

<%-- OLMAZ --%>
<%--<% using.System.Globalization %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
     <%--CSS--%>
    <style>
        #clock{
            width:80%;
            margin:auto;
            text-align:center;
            height:200px;
            line-height:200px;
            color:red;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="clock">
        <%--İlk Web Formum--%>
        <%--Yorum Satırı--%>

        <!-- HTML Comment-->        
        <%-- ASPX Comment (default comment option) --%>

        <%--<span> 9 Kasım 2016 16:13:22</span>--%>
        <span><%= DateTime.Now.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("de-DE")) %></span>   
        <%--Noktalı virgül koymazsan hata verir. Bu hatayı da bize server gösterir. --%> <%-- C#'da yazdığımız kodun soluna eşittir koymamız gerekiyor. Yani değeri atamış oluyoruz. --%>

        <%-- DateTime.Now; --%>
    </div>
    </form>
</body>
</html>
