<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductEditForm.aspx.cs" Inherits="WebForms_Uygulama.ProductEditForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--Değişiklikler Burada Yaıplacak--%>                   
                        <div class="col-md-10 col-md-offset-1">
                                <h4>Yeni Ürün</h4>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtProductName" ID="lblProductName"  runat="server" Text="Ürün Adı :"></asp:Label>    
                                 <asp:TextBox  ID="txtProductName"  runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label  AssociatedControlID="txtUnitInStock" ID="lblUnitInStock" runat="server" Text="Stok Miktarı"></asp:Label>    
                                 <asp:TextBox  ID="txtUnitInStock"   runat="server" CssClass="form-control"></asp:TextBox>
                                   </div>

                                 <div class="form-group">
                                <asp:Label AssociatedControlID="txtDiscount" ID="lblDizcount"  runat="server" Text="Durum :"></asp:Label>    
                                 <asp:TextBox  ID="txtDiscount"  runat="server" CssClass="form-control" ></asp:TextBox>
                            </div> 
                                                                                       
                                <br />
                                <div class="form-group">
                                          <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnSave_Click"/>
                                </div>                       
                         
                        </div>
</asp:Content>