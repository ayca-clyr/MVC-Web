<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductListForm.aspx.cs" Inherits="WebForms_Uygulama.ProductListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <h2>Ürün Listesi</h2>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <a href="ProductEditForm.aspx" class="btn btn-default">Yeni Ürün</a>
                                    <%--Buton gibi görunuyor--%>
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="gridProduct" runat="server" CssClass="table table-bordered">
                            <%--Update/Delete ekleyecez--%>
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <asp:Button CssClass="btn btn-xs btn-default" ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("ProductId") %>'
                                            OnClick="btnDelete_Click" />
                                        <%--OnClick : arkada btn_Click oluşturur.--%>
                                        <%--data-id:'' içinde yazılmalı.--%>
                                        <a class="btn btn-xs btn-default" href='ProductEditForm.aspx?id=<%# Eval ("ProductId") %>'>Düzenle</a>
                                        <%-- Burda Id Diğer sayfaya gönderiyoruz--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--Gride CssClass verdik daha büyük olsun diye--%>

</asp:Content>
