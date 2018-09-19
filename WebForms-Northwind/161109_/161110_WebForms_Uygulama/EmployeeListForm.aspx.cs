using _161110_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _161110_WebForms_Uygulama
{
    public partial class EmployeeListForm : System.Web.UI.Page
    {
        northwindEntities _dbContext;

        //2.Yöntem için
        public List<Employee> _employeeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new northwindEntities();
            // 2.Yöntem için.
            _employeeList = new northwindEntities().Employees.ToList();






            
            //var allEmployee = (from emp in _dbContext.Employees
            //                   select new
            //                   {
            //                       emp.EmployeeID,
            //                       emp.FirstName,
            //                       emp.LastName,
            //                       emp.Address,
            //                       emp.City,
            //                       emp.BirthDate
            //                   }).ToList();
            //EmployeeRepeater.DataSource = allEmployee;
            //EmployeeRepeater.DataBind();
            
        }

  

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string employeeIdStr = (sender as Button).Attributes["data-id"];
            int employeeId = int.Parse(employeeIdStr);

            Employee emp = _dbContext.Employees.Find(employeeId);

            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();

            Response.Redirect("EmployeeListForm.aspx");

        
        }
    }
}