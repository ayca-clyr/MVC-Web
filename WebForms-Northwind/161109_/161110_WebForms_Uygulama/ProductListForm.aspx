<%--  

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductListForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.ProductListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server">
    
    <h2>Ürün Listesi</h2>
                       <div class="row">
                           <div class="col-md-12">
                               <div class="pull-right">
                                   <a href="ProductEditForm.aspx" class="btn btn-default">Yeni Ürün</a>

                               </div>
                           </div>
                       </div>
                        <br />
                        <asp:GridView ID="gridProduct" runat="server" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <asp:Button CssClass="btn btn-xs btn-default" ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("ProductId") %>' OnClick="btnDelete_Click" />  <!--Onclick'de oluşan isim ID'den geliyor.-->
                                        <%-- Data-id kendimiz yazdık. Bundan dolayıda tek tırnakla yazmamız gerekiyor. Yani kendi yazdıklarımız tek tırnakla yazılmalı. --%>
<%--  
                                        <a class="btn btn-xs btn-default" href="ProductEditForm.aspx?id=<%# Eval("ProductId") %>">Düzenle</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>



                        </asp:GridView>  <!-

</asp:Content>

--%>


    <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductListForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.ProductListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server">
  <style>
        .EmployeeInfo {
            border: 1px solid black;
            padding: 5px;
            box-sizing: border-box;
            margin: 3px;
            width: 250px;
            min-height: 100px;
            text-align: center;
            line-height: 15px;
            float: left;
        }
        .EmployeeInfo:hover{
            box-shadow: 0 0 5px 5px silver;
            border-color:silver;
            cursor:pointer;
        }
        </style>
       
    </asp:Content>

   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h2>Ürün Listesi</h2>
    <asp:Repeater ID="Rap" runat="server">
        <ItemTemplate>
            <div class="EmployeeInfo">
                Ad : <strong><%# Eval("ProductName") %></strong> <br />
                Fiyat : <strong><%# Eval("UnitPrice") %></strong> <br />
                Stok : <strong><%# Eval("UnitsInStock") %></strong> <br />
                Kategori : <strong><%# Eval("CategoryName") %></strong>
            </div>
</ItemTemplate>
</asp:Repeater>
</asp:Content>
   



