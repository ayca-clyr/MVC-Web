namespace DataAccessLayer.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.KisiselContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.KisiselContext context)
        {
            User user = new User()
            {
                UserName = "Ayca",
                Password = "123"
            };
            context.User.AddOrUpdate(x => x.UserName, user);

            People people = new People()
            {
                FullName = "temp",
                Title = "temp",
                Age = DateTime.Now,
                Phone = "temp",
                Email = "temp",
                ImageId = 0
            };
            context.People.AddOrUpdate(x => x.FullName, people);
        }
    }
}
