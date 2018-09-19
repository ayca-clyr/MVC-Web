using _161116_EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.EF.Mappings
{
    public class DepartmentMapping
    {

        // İlk Yöntem

        /*
        public DepartmentMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(d => d.Id);
        }
        */
        public static void Map(DbModelBuilder modelBuilder)
        {
            // EntityTypeConfiguration<Department> yaz ve sürekli modelBuilder.Entity<Department>() yazmak zorunda kalmayız.
            EntityTypeConfiguration<Department> entity = modelBuilder.Entity<Department>();
           entity.HasKey(d => d.Id);

           //entity.Property(d => d.Name).IsRequired();
           //entity.Property(d => d.Name).HasMaxLength(50);
           entity.Property(d => d.Name).IsRequired().HasMaxLength(50);

           entity.Property(d => d.Description).HasMaxLength(500);

        }
    }
}