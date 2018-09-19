using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    class SocialMap : EntityTypeConfiguration<Social>
    {
        public SocialMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Facebook).HasColumnType("nvarchar").HasMaxLength(200).IsOptional();
            Property(x => x.Instagram).HasColumnType("nvarchar").HasMaxLength(200).IsOptional();
            Property(x => x.Linkedin).HasColumnType("nvarchar").HasMaxLength(200).IsOptional();
            Property(x => x.GitHub).HasColumnType("nvarchar").HasMaxLength(200).IsOptional();

            HasRequired(x => x.People).WithMany(x => x.Socials).HasForeignKey(x => x.PeopleId).WillCascadeOnDelete(false);

        }
    }
}
