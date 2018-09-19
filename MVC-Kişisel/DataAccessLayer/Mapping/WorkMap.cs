using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class WorkMap : EntityTypeConfiguration<Work>
    {
        public WorkMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Branch).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            Property(x => x.DateOfStart).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(x => x.DateOfEnd).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();

            HasRequired(x => x.People).WithMany(x => x.Works).HasForeignKey(x => x.PeopleId).WillCascadeOnDelete(false);
        }
    }
}
