using MhrsWeb.Areas.AdminPanel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MhrsWeb.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class CommandController : Controller
    {



        MhrsWebDBEntities db = new MhrsWebDBEntities();
        public ActionResult Index()
        {
            List<Command> commandList = db.Command.ToList();
            return View(commandList);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Command command)
        {
            Command newCommand = new Command
            {
                Name = command.Name
            };

            db.Command.Add(newCommand);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id,string SeoText)
        {
            Command command = db.Command.Where(x => x.Id == Id).FirstOrDefault();
            return View(command);
        }

        [HttpPost]
        public ActionResult Edit(Command command)
        {
            Command editCommand = db.Command.Where(x => x.Id == command.Id).FirstOrDefault();
            editCommand.Name = command.Name;

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int Id)
        {
            Command command = db.Command.Where(x => x.Id == Id).FirstOrDefault();

            db.Command.Remove(command);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}