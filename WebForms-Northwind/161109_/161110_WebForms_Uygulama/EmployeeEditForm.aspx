<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeEditForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.EmployeeEditForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server">

    <h4>Yeni Çalışan</h4>

<div class="form-group">
    <asp:Label ID="lblEmployeeFirstName" runat="server" Text="Label">Çalışan Adı</asp:Label>
    <br />
    <asp:TextBox ID="txtBxEmplyeeFirstName" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Label ID="lblEmployeeLastName" runat="server" Text="Label">Çalışan Soyadı</asp:Label>
    <br />
    <asp:TextBox ID="txtBxEmplyeeLastName" runat="server" CssClass="form-control"></asp:TextBox>
</div>



                        
 <div class="form-group">
     <asp:Label ID="lblEmployeeAddress" runat="server" Text="Label">Adress</asp:Label>
     <br />
     <asp:TextBox ID="txtBxEmployeeAddress" runat="server" CssClass="form-control"></asp:TextBox>
 </div>
                        
<div class="form-group">
    <asp:Label ID="lblEmployeeCity" runat="server" Text="Label">Şehir</asp:Label>
    <br />
    <asp:TextBox ID="txtBxEmployeeCity" runat="server" CssClass="form-control"></asp:TextBox>

</div>
 <div class="form-group">
     <asp:Label ID="lblDateOfBirt" runat="server" Text="Label">Doğum Tarihi</asp:Label>
     <br />
     <input type="date" id="dateOfBirth" runat="server"/>

 </div>

<br />

<div class="form-group">
    <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnSave_Click" />
</div>



</asp:Content>
