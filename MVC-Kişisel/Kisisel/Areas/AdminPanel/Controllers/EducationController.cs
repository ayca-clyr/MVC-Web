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
    public class EducationController : Controller
    {
        EducationBLL _educationBLL = new EducationBLL();
        // GET: AdminPanel/Education
        public ActionResult Index()
        {
            List<Education> educationList = _educationBLL.GetAll();
            return View(educationList);
        }

        public ActionResult EducationDelete(int Id)
        {
            Education education = _educationBLL.Get(Id);
            _educationBLL.Remove(education);
            return RedirectToAction("Index");
        }

        public ActionResult EducationAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EducationAdd(Education education)
        {
            int peopleId = _educationBLL.GetPeopleId();
            Education newEducation = new Education();

            if ((!string.IsNullOrWhiteSpace(education.Name)) && education.Name != null)
            {
                newEducation.Name = education.Name;
            }
            if ((!string.IsNullOrWhiteSpace(education.Branch)) && education.Branch != null)
            {
                newEducation.Branch = education.Branch;
            }
            if ((!string.IsNullOrWhiteSpace(education.DateOfStart)) && education.DateOfStart != null)
            {
                newEducation.DateOfStart = education.DateOfStart;
            }
            if ((!string.IsNullOrWhiteSpace(education.DateOfEnd)) && education.DateOfEnd != null)
            {
                newEducation.DateOfEnd = education.DateOfEnd;
            }

            newEducation.PeopleId = peopleId;

            _educationBLL.Add(newEducation);

            return RedirectToAction("Index");
        }

        public ActionResult EducationUpdate(int Id)
        {
            Education education = _educationBLL.Get(Id);
            return View(education);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EducationUpdate(Education education)
        {
            Education updateEducation = _educationBLL.Get(education.Id);

            if ((!string.IsNullOrWhiteSpace(education.Name)) && education.Name != null)
            {
                updateEducation.Name = education.Name;
            }
            if ((!string.IsNullOrWhiteSpace(education.Branch)) && education.Branch != null)
            {
                updateEducation.Branch = education.Branch;
            }
            if ((!string.IsNullOrWhiteSpace(education.DateOfStart)) && education.DateOfStart != null)
            {
                updateEducation.DateOfStart = education.DateOfStart;
            }
            if ((!string.IsNullOrWhiteSpace(education.DateOfEnd)) && education.DateOfEnd != null)
            {
                updateEducation.DateOfEnd = education.DateOfEnd;
            }
            
            _educationBLL.Update(updateEducation);

            return RedirectToAction("Index");
        }

    }
}