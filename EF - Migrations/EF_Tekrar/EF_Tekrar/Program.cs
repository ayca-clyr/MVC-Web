using EF_Tekrar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tekrar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Çoktan coka nasıl veri atanır.
            OkulContext db = new OkulContext();

            Öğrenci o = new Öğrenci();
            o.Ad = "Burak Hamdi";
            o.Soyad = "Kaya";
            o.DogumTarihi = new DateTime(200, 1, 1);
            o.Email = "crazyBoy_123@yahoo.com";

            db.Öğrenciler.Add(o);
            db.SaveChanges();

            //Ders aç
            //o derse öğrenci ekle
            //ara tablo oluşturuluyor.
            //yada oğrnciye ders eklenecek.
            Ders d = new Ders();
            d.Ad = "Müzik";

            d.Öğrenciler.Add(o); //yukardaki derse yukardaki öğrencileri ekle yada
           // o.Dersler.Add(d); //yukardaki öğrenciye yukardeki dersi ekle.

            Ders d2 = new Ders();
            d2.Ad = "Resim";

            d.Öğrenciler.Add(o);

            db.Dersler.Add(d);
            db.SaveChanges();

            //LAZY LOADING
            //EAGER LOADING

           // db.Configuration.LazyLoadingEnabled = false; lazy load kapatır.lazy olmadan proxy olur.
            db.Configuration.ProxyCreationEnabled = false; //Proxy oluşmasını engeller.Proxy olmadan lazy olmaz

            var entities = db.ChangeTracker.Entries(); //suan içi boş

            Ders ders = db.Dersler.First();     //Kaç öğrenci var sayıyor
            Öğrenci öğrenci = d.Öğrenciler.First();
            öğrenci.Ad = "Burak";
            Console.WriteLine(öğrenci.Ad);
        
            var entities2 = db.ChangeTracker.Entries();

            //Console.ReadKey();
        }
    }
}
