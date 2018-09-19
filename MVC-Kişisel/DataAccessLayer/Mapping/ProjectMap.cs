using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Description).HasColumnType("nvarchar(max)").IsRequired();
            Property(x => x.Link).HasColumnType("nvarchar(max)").IsOptional();

            HasRequired(x => x.People).WithMany(x => x.Projects).HasForeignKey(x => x.PeopleId).WillCascadeOnDelete(false);
            HasRequired(x => x.Image).WithMany(x => x.Projects).HasForeignKey(x => x.ImageId).WillCascadeOnDelete(false);
            HasRequired(x => x.Category).WithMany(x => x.Projects).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);




        }
    }
}
