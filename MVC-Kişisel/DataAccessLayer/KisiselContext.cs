using DataAccessLayer.Mapping;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class KisiselContext : DbContext
    {
        public KisiselContext() : base("Kisisel")
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Social> Social { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project_Technology> Project_Technology { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new EducationMap());
            modelBuilder.Configurations.Add(new WorkMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new PeopleMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new SocialMap());
            modelBuilder.Configurations.Add(new TechnologyMap());
            modelBuilder.Configurations.Add(new UserMap());

           

            base.OnModelCreating(modelBuilder);
        }

    }
}
