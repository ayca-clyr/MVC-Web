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
    public class SkillController : Controller
    {
        SkillBLL _skillBLL = new SkillBLL();
        // GET: AdminPanel/Skill
        public ActionResult Index()
        {
            List<Skill> skillList = _skillBLL.GetAll();
            return View(skillList);
        }

        [HttpPost]
        public ActionResult SkillAdd(string deger, string deger2)
        {
            int peopleId = _skillBLL.GetPeopleId();
            Skill skill = new Skill();
            skill.Name = deger;
            skill.Grade = deger2;
            skill.PeopleId = peopleId;

            _skillBLL.Add(skill);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SkillUpdate(int id, string deger, string deger1)
        {
            int peopleId = _skillBLL.GetPeopleId();
            Skill skill = _skillBLL.Get(id);
            skill.Name = deger;
            skill.Grade = deger1;
            skill.PeopleId = peopleId;

            _skillBLL.Update(skill);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SkillDelete(int id)
        {

            Skill skill = _skillBLL.Get(id);
           
            _skillBLL.Remove(skill);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}