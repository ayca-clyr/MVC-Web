<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductEditForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.ProductEditForm" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBody" runat="server"> 

<h4>Yeni Ürün</h4>

                        <div class="form-group">
                            <asp:Label ID="lblProductName" runat="server" Text="Label">Ürün Adı</asp:Label>
                            <br />
                            <asp:TextBox ID="txtBxProductName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                      
                        <div class="form-group">
                            <asp:Label ID="lblUnitsInStock" runat="server" Text="Label">Stok Miktarı</asp:Label>
                            <br />
                            <asp:TextBox ID="txtBxProductUnitInStock" runat="server"  CssClass="form-control"></asp:TextBox>
                          
                        </div>
                        <br />
                       <div class="form-group">
                            <asp:Label ID="lblProductDiscontinued" runat="server" Text="Label">Durum :</asp:Label>
                            <br />
                           <asp:CheckBox ID="cBxProductDiscontinued1" runat="server" CssClass="form-control" Text="True" />
                         
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>



</asp:Content>
