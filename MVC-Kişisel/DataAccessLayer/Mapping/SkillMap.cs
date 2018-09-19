using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Grade).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            HasRequired(x => x.People).WithMany(x => x.Skills).HasForeignKey(x => x.PeopleId).WillCascadeOnDelete(false);
        }
    }
}
