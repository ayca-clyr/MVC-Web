using _161116_EmployeeManagement.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.EF.Mappings
{
    public class EmployeeMapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Employee> entity = modelBuilder.Entity<Employee>();

            // varchar --> 50 + 2 = 52
            // nvarchar --> 50 * 2 + 2 = 102

            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnType("date").IsOptional();
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20); // Zorunlu değil 
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity  
                           //.WithRequiredDependent() --> 1'e 1 ilişki.   Dependent => Bağımlı 
                             .HasRequired(e => e.Department)               
                             .WithMany(d=>d.Employees)
                             .HasForeignKey(e=> e.DepartmentId)
                             .WillCascadeOnDelete(false);   // Buna ait employeeler silinsin mi silinmesin mi? (İlişkili kayıtlar)
            



            

        }
    }
}