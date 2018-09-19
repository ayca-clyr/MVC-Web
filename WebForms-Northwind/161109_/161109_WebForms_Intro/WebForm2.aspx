<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="_161109_WebForms_Intro.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            height: 535px;
            width: 848px;
        }
    </style>
</head>
<body style="height: 19px; width: 774px">
    <form id="form1" runat="server">
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" style="margin-left: 307px" Width="201px"></asp:TextBox>
        </p>
        <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" style="margin-left: 307px" Width="201px"></asp:TextBox>
        <br /> 
        <br />    
        <input type="text" style="width: 201px; margin-left: 307px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 386px" Text="Button" />

        <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
        <button id="Button_html"  runat="server">Button</button> 
        <br />
        <input type="button" id="Button_input" runat="server" value="Button" />
    </form>
</body>
</html>
