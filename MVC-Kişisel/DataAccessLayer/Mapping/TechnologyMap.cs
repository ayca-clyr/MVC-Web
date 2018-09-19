using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class TechnologyMap : EntityTypeConfiguration<Technology>
    {
        public TechnologyMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        }
    }
}
