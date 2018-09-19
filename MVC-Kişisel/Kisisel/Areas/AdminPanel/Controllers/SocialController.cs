using BusinessLayer;
using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class SocialController : Controller
    {
        SocialBLL _socialBLL = new SocialBLL();
        // GET: AdminPanel/Social
        public ActionResult Index()
        {
            List<Social> socialList = _socialBLL.GetAll();
            return View(socialList);
        }

        public ActionResult SocialDelete(int Id)
        {
            Social social = _socialBLL.Get(Id);
            _socialBLL.Remove(social);
            return RedirectToAction("Index");
        }
        public ActionResult SocialAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SocialAdd(Social social)
        {
            int peopleId = _socialBLL.GetPeopleId();
            Social newSocial = new Social();

            if ((!string.IsNullOrWhiteSpace(social.Facebook)) && social.Facebook != null)
            {
                newSocial.Facebook = social.Facebook;
            }
            if ((!string.IsNullOrWhiteSpace(social.Instagram)) && social.Instagram != null)
            {
                newSocial.Instagram = social.Instagram;
            }
            if ((!string.IsNullOrWhiteSpace(social.Linkedin)) && social.Linkedin != null)
            {
                newSocial.Linkedin = social.Linkedin;
            }
            if ((!string.IsNullOrWhiteSpace(social.GitHub)) && social.GitHub != null)
            {
                newSocial.GitHub = social.GitHub;
            }

            newSocial.PeopleId = peopleId;

            _socialBLL.Add(newSocial);

            return RedirectToAction("Index");
        }

        public ActionResult SocialUpdate(int Id)
        {
            Social social = _socialBLL.Get(Id);
            return View(social);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SocialUpdate(Social social)
        {
            Social updateSocial = _socialBLL.Get(social.Id);

            if ((!string.IsNullOrWhiteSpace(social.Facebook)) && social.Facebook != null)
            {
                updateSocial.Facebook = social.Facebook;
            }
            if ((!string.IsNullOrWhiteSpace(social.Instagram)) && social.Instagram != null)
            {
                updateSocial.Instagram = social.Instagram;
            }
            if ((!string.IsNullOrWhiteSpace(social.Linkedin)) && social.Linkedin != null)
            {
                updateSocial.Linkedin = social.Linkedin;
            }
            if ((!string.IsNullOrWhiteSpace(social.GitHub)) && social.GitHub != null)
            {
                updateSocial.GitHub = social.GitHub;
            }

            _socialBLL.Update(updateSocial);

            return RedirectToAction("Index");
        }
    }
}