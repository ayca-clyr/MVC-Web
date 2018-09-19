using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class EmployeeEditForm : System.Web.UI.Page
    
    {
        northwindEntities _dbContext;
        Employee _emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new northwindEntities();

            string employeeIdStr = Request.QueryString["id"];  //?id dediğimiz kısım.


            employeeIdStr = employeeIdStr ?? "0";

            int employeeId = int.Parse(employeeIdStr);


            if (employeeId == 0)
            {
                // Yeni Kayıt
                _emp = new Employee();
            }
            else
            {
                // Güncelle
                _emp = _dbContext.Employees.Find(employeeId);



                if (!Page.IsPostBack)
                {

                    txtBxEmplyeeFirstName.Text = _emp.FirstName;
                    txtBxEmplyeeLastName.Text = _emp.LastName;
                    txtBxEmployeeCity.Text = _emp.City;
                    txtBxEmployeeAddress.Text = _emp.Address;
                    dateOfBirth.Value = _emp.BirthDate.Value.ToShortDateString();


                }

                btnSave.Text = "Güncelle";

            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _emp.FirstName = txtBxEmplyeeFirstName.Text;
            _emp.LastName = txtBxEmplyeeLastName.Text;
            _emp.Address = txtBxEmployeeAddress.Text;
            _emp.City = txtBxEmployeeCity.Text;
            _emp.BirthDate = DateTime.Parse(dateOfBirth.Value);

            if (_emp.EmployeeID == 0)
            {


                _dbContext.Employees.Add(_emp);
            }

            _dbContext.SaveChanges();

            Response.Redirect("EmployeeListForm.aspx");   
        }
    }
}