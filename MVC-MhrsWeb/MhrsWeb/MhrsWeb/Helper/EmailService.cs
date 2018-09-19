using MhrsWeb.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MhrsWeb.Helper
{
    public class EmailService
    {

        public MailSendStatus SendMail(Kullanici kullanici)
        {

            MhrsWebDBEntities db = new MhrsWebDBEntities();
            Md5Service md5Service = new Md5Service();
            Kullanici kullaniciKontrol = db.Kullanici.Where(x => x.Email == kullanici.Email).FirstOrDefault();
            Login login = db.Login.Where(x => x.Kullanici.Email == kullanici.Email).FirstOrDefault();

            if(login == null)
                return MailSendStatus.KAYITLI;

            if (kullaniciKontrol == null)
                return MailSendStatus.KAYITLI;

            try
            {
                string fullName = login.Kullanici.Name + " " + login.Kullanici.Surname;
                string yeniSifre = CreatePassword(5);
                login.Password = md5Service.Md5Sifre(yeniSifre);
                login.Durum = true;
                db.SaveChanges();

                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com", 587);
                mail.From = new MailAddress("ingamedemotest@gmail.com", "Bkaya123.");
                mail.To.Add(kullanici.Email.ToString());
                mail.Subject = "Mhrs Sifre Hatirlatma";
                mail.Body = "Sn. "+fullName+ ", Sistemde kayıtlı olan şifreniz : " + yeniSifre;
                smtpServer.Credentials = new NetworkCredential("ingamedemotest@gmail.com", "Bkaya123.");
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);

                return MailSendStatus.BASARILI;
            }
            catch (Exception)
            {
                return MailSendStatus.BASARISIZ;
            }


            #region WebConfig ile Mail Gönderimi 2.Yol
            //try
            //{
            //    using (var client = new SmtpClient("smtp.gmail.com", 587))
            //    {
            //        MailMessage mail = new MailMessage();
            //        mail.Subject = "Mhrs Sifre Hatirlatma";
            //        mail.Body = "Sistemde kayıtlı olan şifreniz" + sifre; ;
            //        mail.From = new MailAddress("ingamedemotest@gmail.com", "Bkaya123.");
            //        mail.To.Add(kullanici.Email.ToString());
            //        client.Send(mail);
            //    }
            //}
            //catch (Exception)
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu Lütfen Daha Sonra Tekrar Deneyiniz! ');window.location = '/Login/Index';</script>");
            //}

            //return Content("<script language='javascript' type='text/javascript'>alert('Mail Gönderildi');window.location = '/Login/Index';</script>");





            //WEBCONFIGE YAZILACAK KOD
            //<system.net>
            //<mailSettings>
            //<smtp deliveryMethod="Network" from="ingamedemotest@gmail.com">
            //<network host="smtp.host.net" userName="ingamedemotest@gmail.com" password="Bkaya123." port="587" enableSsl="true" />
            //</smtp>
            //</mailSettings>
            //</system.net>



            #endregion

        }


        public string CreatePassword(int size)
        {
            char[] cr = "0123456789ABCDEFGHIJKLMNOPQRSTUCWXYZ".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < size; i++)
                result += cr[r.Next(0, cr.Length - 1)].ToString();

            return result;
        }



    }
}