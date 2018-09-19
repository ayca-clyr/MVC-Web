using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class Project_TechnologyMap : EntityTypeConfiguration<Project_Technology>
    {
        public Project_TechnologyMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Project).WithMany(x => x.Project_Technologies).HasForeignKey(x => x.ProjectId).WillCascadeOnDelete(false);
            HasRequired(x => x.Technology).WithMany(x => x.Projects_Technologies).HasForeignKey(x => x.TechnologyId).WillCascadeOnDelete(false);
        }
    }
}
