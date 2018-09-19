using _161116_EmployeeManagement.EF.Entities;
using _161116_EmployeeManagement.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace _161116_EmployeeManagement.EF
{
    public class DataContext :DbContext
    {

        public DataContext():base("EmployeeManagementConnection")
        {
            base.Configuration.LazyLoadingEnabled = true;
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Mapping klasörüne yazdığımız için bunlara gerek kalmadı.
            modelBuilder.Entity<Department>().HasKey(d => d.Id);
            //modelBuilder.Entity<Department>().HasRequired(d => d.Name);
            modelBuilder.Entity<Department>().Property(d => d.Name).IsRequired();
        */
            // İlk Yöntemdeki Yani Ctor'a yazdığımızda bu şekilde çağrıyoruz.
            //new Mappings.DepartmentMapping(modelBuilder); 
            Mappings.DepartmentMapping.Map(modelBuilder);
            Mappings.EmployeeMapping.Map(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            

        }
       
    }
}