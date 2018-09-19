<%@ Page Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryEditForm.aspx.cs" Inherits="WebForms_Uygulama.CategoryEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--Değişiklikler Burada Yaıplacak--%>                   
                        <div class="col-md-10 col-md-offset-1">
                                <h4>Yeni Kategori</h4>
                            <div class="form-group">
                                <asp:Label AssociatedControlID="txtCategoryName" ID="lblCategoryName"  runat="server" Text="Kategori Adı :"></asp:Label>    
                                 <asp:TextBox  ID="txtCategoryName"  runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label  AssociatedControlID="txtDescription" ID="lblDescription" runat="server" Text="Açıklama:"></asp:Label>    
                                 <asp:TextBox  ID="txtDescription"   runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>                           
                                <%--TextMode="MultiLine" deyince TextArea gibi büyür.--%>     
                                <br />
                                <div class="form-group">
                                          <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="Button1_Click"/>
                                </div>                       
                            </div>
                        </div>
</asp:Content>
               