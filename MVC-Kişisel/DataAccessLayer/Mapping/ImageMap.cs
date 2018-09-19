using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnType("nvarchar(max)").IsRequired();
            Property(x => x.ImgUrl).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
