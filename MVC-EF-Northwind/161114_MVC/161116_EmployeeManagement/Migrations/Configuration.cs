namespace _161116_EmployeeManagement.Migrations
{
    using _161116_EmployeeManagement.EF.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_161116_EmployeeManagement.EF.DataContext>
    {
       // Migration veritabanýnda tablo deðiþikliði yapýlýrsa..
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_161116_EmployeeManagement.EF.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            Department yazilimDepartment = new Department() { Name = "Yazýlým", Description = "Yazýlým Proje Geliþtirme" };
            Department sistemDepartment = new Department() { Name = "Sistem", Description = "Sistem,Network,Güvenlik" };

            context.Departments.AddOrUpdate
                           (
                           d => d.Name,  // Bu isme bak. Eðer yoksa ekle varsa güncelle.
                          yazilimDepartment,
                          sistemDepartment
                           );  // Sürekli migration yaparsak var olan kayýtlarýn katý þeklinde olur. O Yüzden ekle ve ya güncelle diyoruz.
            // Id eklemek zorundayýz. Ama daha veri olmadýðý için Id gelmicek. Bu yüzden bu þekilde yazdýk.
            context.Employees.AddOrUpdate(
                e => e.FirstName,
                new Employee()
                {
                    FirstName = "Tsubasa",
                    LastName = "Ozara",
                    Department = yazilimDepartment,
                    Salary = 1800,
                    Gender = Gender.Male,
                    //DateOfBirth = DateTime.Parse("1.1.1998"),
                    EmailAddress = "tsubasa@ozara.com"
                },
                 new Employee()
                 {
                     FirstName = "Misaki",
                     LastName = "Taro",
                     Department = sistemDepartment,
                     Salary = 1400,
                     Gender = Gender.Male,
                     EmailAddress = "misaki@taro.com"
                 },
                 new Employee()
                 {
                     FirstName = "Serkan",
                     LastName = "Soydam",
                     Department = yazilimDepartment,
                     Salary = 2300,
                     Gender = Gender.Female,
                     EmailAddress = "serkan@soydam.com"
                 }
                );
        }
    }
}
