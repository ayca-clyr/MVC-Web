<%@ Page Language="C#" Title="" MasterPageFile="~/Site1.Master" AutoEventWireup ="true" CodeBehind="CategoryEditForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.CategoryEditForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server"> 

<h4>Yeni Kategori</h4>

                        <div class="form-group">
                            <asp:Label ID="lblCategoryName" runat="server" Text="Label">Kategori Adı</asp:Label>
                            <br />
                            <asp:TextBox ID="txtBxCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                      
                        <div class="form-group">
                            <asp:Label ID="lblDescription" runat="server" Text="Label">Kategori Açıklaması</asp:Label>
                            <br />
                            <asp:TextBox ID="txtBxCategoryDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            <%-- TextBox'ın TextMode=Multiline dersek biz bunu textarea yapmış oluruz. --%>
                        </div>
                        <br />
                       
                        <div class="form-group">
                            <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>



</asp:Content>

 