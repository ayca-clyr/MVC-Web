using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.EF.Entities
{
    public class Department
    {
        // Liste varsa instance'sini ctor'da al.
        public Department()
        {
            Employees = new HashSet<Employee>();
            //Employees = new ICollection<Employee>(); // Interface'in instance'ı asla alınamaz.
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }  // Hem HashSet hem List hemde Collection şeklinde tutar. Tek tipe bağımlı değil.
    }
}