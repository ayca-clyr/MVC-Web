using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tekrar.EF
{
    class OkulContext:DbContext 
    {
        public OkulContext ()//:base()
	{
                
	}
        public virtual DbSet<Öğrenci> Öğrenciler { get;set; }
        public virtual DbSet<Ders> Dersler { get; set; }
        //Context class içerisindeki DBSetlerin Virtual olmasının sebebi : UNIT TEST

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mapleme işlemleri
            base.OnModelCreating(modelBuilder);
        }
    }


}
