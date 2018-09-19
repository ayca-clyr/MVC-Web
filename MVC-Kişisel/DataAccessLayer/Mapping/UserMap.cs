using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.Id);
            Property(x => x.UserName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}
