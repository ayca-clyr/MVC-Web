<%--  
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeListForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.EmployeeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBody" runat="server">


    <h2>Çalışan Listesi</h2>
    <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="EmployeeEditForm.aspx" class="btn btn-default">Yeni Çalışan</a>

            </div>
        </div>
    </div>
    <br />
    <div>
        <table style="width:600px" border="1">

<thead>
    <tr>
        <th>EmployeeID</th>
        <th>Adı</th>
        <th>Soyadı</th>
        <th>Adres</th>
        <th>Şehir</th>
        <th>Doğum Tarihi</th>
        <th>#</th>
    </tr>

</thead>
            <tbody>
                <asp:Repeater ID="EmployeeRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("EmployeeId") %></td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("Address") %></td>
                            <td><%# Eval("City") %></td>
                            <td><%# Eval("BirthDate") %></td>
                            <td>

                                <asp:Button CssClass="btn btn-xs btn-default" ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("EmployeeId") %>' OnClick="btnDelete_Click" />
                                        <a class="btn btn-xs btn-default" href="EmployeeEditForm.aspx?id=<%# Eval("EmployeeId") %>">Düzenle</a>

                            </td>
                        </tr>
                       
                    </ItemTemplate>


                </asp:Repeater>


            </tbody>
        </table>

    </div>
   
    

  </asp:Content>

    --%>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeListForm.aspx.cs" Inherits="_161110_WebForms_Uygulama.EmployeeListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

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
   <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceBody" runat="server">

    <h2>Çalışan Listesi</h2>
          
         <%--   <div class="EmployeeInfo">
                Adı : <strong> </strong> <br />
                Soyadı : <strong></strong> <br />
                Ünvan : <strong></strong> <br />
                Dt : <strong></strong>
            </div>--%>

            <% 
                for(int i = 0; i < _employeeList.Count; i++){
                %>
        <div class="EmployeeInfo">
            <img src="/image.aspx?id=<%= _employeeList[i].EmployeeID %>" />
            <%--<img src="<%= _employeeList[i].Photo == null ? "" : "data:Image/png;base64"+Convert.ToBase64String(_employeeList[i].Photo.Skip(78).ToArray()) %>" />--%><br />

                Adı : <strong><%= _employeeList[i].FirstName %></strong> <br />
                Soyadı : <strong><%= _employeeList[i].LastName %></strong> <br />
                Ünvan : <strong><%= _employeeList[i].Title %></strong> <br />
                Dt : <strong><%= _employeeList[i].BirthDate.HasValue ? _employeeList[i].BirthDate.Value.ToShortDateString() : "<data yok>" %></strong>
            </div>

       <%}
                %>

</asp:Content>
   

    
    
    
    
    
    
    
    
    
    
    
    
    
   
