using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class PeopleMap : EntityTypeConfiguration<People>
    {
        public PeopleMap()
        {
            HasKey(x => x.Id);
            Property(x => x.FullName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Age).HasColumnType("date").IsRequired();
            Property(x => x.Phone).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(x => x.Address).HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.ImageId).HasColumnType("int").IsOptional();
            
        }
    }
}
