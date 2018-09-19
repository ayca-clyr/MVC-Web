using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.Models
{
    // Listede her alanı göstermek istemediğim için Entity dışında buraya yazdık istediklerimizi. Ve o şekilde çağırdık. Çağrırkende Model'den çağrıyoruz. Diğerinde Entity'den çağrıyoruz.
    public partial class EmployeeListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
    }
}