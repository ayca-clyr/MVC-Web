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
    public class WorkController : Controller
    {
        WorkBLL _workBLL = new WorkBLL();
        // GET: AdminPanel/Work
        public ActionResult Index()
        {
            List<Work> workList = _workBLL.GetAll();
            return View(workList);
        }

        public ActionResult WorkDelete(int Id)
        {
            Work work = _workBLL.Get(Id);
            _workBLL.Remove(work);
            return RedirectToAction("Index");
        }
        public ActionResult WorkAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WorkAdd(Work work)
        {
            int peopleId = _workBLL.GetPeopleId();
            Work newWork = new Work();

            if ((!string.IsNullOrWhiteSpace(work.Name)) && work.Name != null)
            {
                newWork.Name = work.Name;
            }
            if ((!string.IsNullOrWhiteSpace(work.Branch)) && work.Branch != null)
            {
                newWork.Branch = work.Branch;
            }
            if ((!string.IsNullOrWhiteSpace(work.DateOfStart)) && work.DateOfStart != null)
            {
                newWork.DateOfStart = work.DateOfStart;
            }
            if ((!string.IsNullOrWhiteSpace(work.DateOfEnd)) && work.DateOfEnd != null)
            {
                newWork.DateOfEnd = work.DateOfEnd;
            }

            newWork.PeopleId = peopleId;

            _workBLL.Add(newWork);

            return RedirectToAction("Index");
        }

        public ActionResult WorkUpdate(int Id)
        {
            Work work = _workBLL.Get(Id);
            return View(work);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WorkUpdate(Work work)
        {
            Work updateWork = _workBLL.Get(work.Id);

            if ((!string.IsNullOrWhiteSpace(work.Name)) && work.Name != null)
            {
                updateWork.Name = work.Name;
            }
            if ((!string.IsNullOrWhiteSpace(work.Branch)) && work.Branch != null)
            {
                updateWork.Branch = work.Branch;
            }
            if ((!string.IsNullOrWhiteSpace(work.DateOfStart)) && work.DateOfStart != null)
            {
                updateWork.DateOfStart = work.DateOfStart;
            }
            if ((!string.IsNullOrWhiteSpace(work.DateOfEnd)) && work.DateOfEnd != null)
            {
                updateWork.DateOfEnd = work.DateOfEnd;
            }

            _workBLL.Update(updateWork);

            return RedirectToAction("Index");
        }

    }
}