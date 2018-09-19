<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03_WebForm2.aspx.cs" Inherits="_161109_WebForms_Intro.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="18px" style="margin-left: 304px; margin-top: 53px" Width="210px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
        </p>
        <asp:TextBox ID="TextBox2" runat="server" Height="18px" style="margin-left: 304px" Width="210px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        <input type="text" style="width:210px; margin-left:307px"/>
        <br />
        <br />
        <br />
        <br />
       <input type="button" id="Button_Input" runat="server"/>
        <br />
        <br />
        <button id="Button_html" runat="server"></button>
        <br />      
    </form>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
