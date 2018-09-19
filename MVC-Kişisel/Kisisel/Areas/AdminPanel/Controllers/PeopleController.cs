using BusinessLayer;
using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class PeopleController : Controller
    {
        PeopleBLL _peopleBLL = new PeopleBLL();
        // GET: AdminPanel/People
        public ActionResult Index()
        {
            People people = _peopleBLL.GetAll().FirstOrDefault();
            return View(people);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(People People, HttpPostedFileBase File, string Age)
        {
            People people = _peopleBLL.GetAll().FirstOrDefault();

            if (People != null)
            {

                if ((!string.IsNullOrWhiteSpace(People.FullName)) && People.FullName != null)
                {
                    people.FullName = People.FullName;
                }
                if ((!string.IsNullOrWhiteSpace(People.Title)) && People.Title != null)
                {
                    people.Title = People.Title;
                }
                if ((!string.IsNullOrWhiteSpace(People.Phone)) && People.Phone != null)
                {
                    people.Phone = People.Phone;
                }
                if ((!string.IsNullOrWhiteSpace(People.Email)) && People.Email != null)
                {
                    people.Email = People.Email;
                }
                if ((!string.IsNullOrWhiteSpace(People.Address)) && People.Address != null)
                {
                    people.Address = People.Address;
                }
                if ((!string.IsNullOrWhiteSpace(Age)) && Age != null)
                {
                    people.Age = DateTime.Parse(Age);
                }
            }


            if (File != null)
            {
                Image image = new Image();

                var fileName = DateTime.Today.ToLongDateString().Replace(" ", "-") + DateTime.Now.ToLongTimeString().Replace(":", "-") + Path.GetFileName(File.FileName);
                //Dosyanın hangi dizine kayıt olacağını belirtiyorsun isimle birlikte combin yapılıyor.
                var path = Path.Combine(Server.MapPath("/Assets/img/"), fileName);
                if (people.ImageId > 0 )
                {
                    Image deleteImage = _peopleBLL.GetImageForId(people.ImageId);

                    var fileName2 = deleteImage.Name;
                    //Dosyanın hangi dizine kayıt olacağını belirtiyorsun isimle birlikte combin yapılıyor.
                    var path2 = Path.Combine(Server.MapPath("/Assets/img/"), fileName2);
                    System.IO.File.Delete(path2);
                    _peopleBLL.RemoveImage(deleteImage);
                }
                File.SaveAs(path);
                image.ImgUrl = "/Assets/img/" + fileName;
                image.Name = fileName;
                _peopleBLL.ImageAdd(image);
                int lastImageId = _peopleBLL.GetImage().Id;
                people.ImageId = lastImageId;
            }

            _peopleBLL.Update(people);


            return RedirectToAction("Index", "Home");
        }


    }
}