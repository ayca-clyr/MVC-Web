using _161116_EmployeeManagement.EF;
using _161116_EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.Helpers
{
    public class LoginHelper
    {
        internal bool LoginUser(string userId, string password, string rememberMe, HttpSessionStateBase Session, HttpResponse Response)
        {
            Employee emp = new DataContext().Employees.FirstOrDefault(x => x.UserId == userId && x.Password == password);
            if (emp != null)
            {
                Session["PersonId"] = emp.Id;

                if (!string.IsNullOrEmpty(rememberMe) && rememberMe == "on")
                {

                    Response.Cookies["UserId"].Value = userId;
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddYears(1); // 1 yıl ismi sakla

                    Response.Cookies["Password"].Value = password;
                    Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1); // 1 yıl ismi sakla

                }

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}