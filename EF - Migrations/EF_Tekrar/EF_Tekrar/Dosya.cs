using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tekrar
{
    [Table("Öğrenci")]
    public class Öğrenci
    {
        public Öğrenci()
        {
            Dersler = new List<Ders>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Email { get; set; }

        //Navigation Property
        public  virtual List<Ders> Dersler { get; set; }

        //Navigation Propertylerdeki virtual anahtar 
    }

    [Table("Ders")]
    public class Ders
    {
        public Ders()
        {
            Öğrenciler = new List<Öğrenci>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }

        //Navigation Property
        public virtual List<Öğrenci> Öğrenciler { get; set; }
    }
    //1.App.config içine  yaz:
    // <connectionStrings>
    //  <!--Machine Config -->
    //<clear/>
    //<add name="OkulContext" connectionString="server=.;database=V2OkulDB;uid=sa;pwd=q" providerName="System.Data.SqlClient"/>
    //  </connectionStrings>

    //2.Referance girip Entity İndirecez.

    //3.Nugget ac.

    //4.enable-migrations yazıyoruz.
    //Applying explicit migrations:[201610251327086_Email Eklendi] silinir
    //Update-Database -TargetMigration: ilkDbOluşturma
    //Update-Database -TargetMigration: Email Eklendi Öğrencilere yeni property eklenince.
    //Update-database Günceller değişiklikleri

}
