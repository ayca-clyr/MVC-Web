<%@ Page Language="C#" Title="" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryListForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.CategoryListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server"> 
<h2>Kategori Listesi</h2>
                       <div class="row">
                           <div class="col-md-12">
                               <div class="pull-right">
                                   <a href="CategoryEditForm.aspx" class="btn btn-default">Yeni Kategori</a>

                               </div>
                           </div>
                       </div>
                        <br />
                        <asp:GridView ID="gridCategories" runat="server" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <asp:Button CssClass="btn btn-xs btn-default" ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("CategoryId") %>' OnClick="btnDelete_Click" />  <!--Onclick'de oluşan isim ID'den geliyor.-->
                                        <%-- Data-id kendimiz yazdık. Bundan dolayıda tek tırnakla yazmamız gerekiyor. Yani kendi yazdıklarımız tek tırnakla yazılmalı. --%>
                                        <a class="btn btn-xs btn-default" href="CategoryEditForm.aspx?id=<%# Eval("CategoryId") %>">Düzenle</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>



                        </asp:GridView>  <!-- Design'dan GridView attık.-->

</asp:Content>

 