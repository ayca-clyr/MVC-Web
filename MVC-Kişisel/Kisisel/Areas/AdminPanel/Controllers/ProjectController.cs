using BusinessLayer;
using Entities;
using Kisisel.Areas.AdminPanel.Helper;
using Kisisel.Areas.AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kisisel.Areas.AdminPanel.Controllers
{
    [LoginRequired]
    public class ProjectController : Controller
    {
        ProjectBLL _projectBLL = new ProjectBLL();
        // GET: AdminPanel/Project
        public ActionResult Index()
        {
            List<Project> projectList = _projectBLL.GetAll();
            return View(projectList);
        }

        public ActionResult ProjectDelete(int Id)
        {
            Project project = _projectBLL.Get(Id);

            
            List<Project_Technology> project_TechnologyList = _projectBLL.GetProject_Technology(project.Id);
            foreach (Project_Technology item in project_TechnologyList)
            {
                _projectBLL.RemoveProject_Technology(item);
            }
            
            Image image = _projectBLL.GetImage(project.ImageId);

            var fileName2 = image.Name;
            var path2 = Path.Combine(Server.MapPath("/Assets/img/"), fileName2);
            System.IO.File.Delete(path2);

            _projectBLL.Remove(project);
            _projectBLL.RemoveImage(image);
            

            


            return RedirectToAction("Index");
        }


        public ActionResult ProjectAdd()
        {
            ProjectAddModel model = new ProjectAddModel();
            model.categoryList = _projectBLL.GetAllCategory();
            model.technologyList = _projectBLL.GetAllTechnology();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProjectAdd(Project project, int CategoryId, int[] TechnologyId, HttpPostedFileBase File)
        {


            if (project.Title != null && project.Description != null && File != null && CategoryId != 0 && TechnologyId != null)
            {
                int peopleId = _projectBLL.GetPeopleId();


                //Filename = dosyanın sunucudaki adını oluşturuyor
                var fileName = DateTime.Today.ToLongDateString().Replace(" ", "-") + DateTime.Now.ToLongTimeString().Replace(":", "-") + Path.GetFileName(File.FileName);

                //Dosyanın hangi dizine kayıt olacağını belirtiyorsun isimle birlikte combin yapılıyor.
                var path = Path.Combine(Server.MapPath("/Assets/img/"), fileName);

                //Kayıt.
                File.SaveAs(path);

                Image image = new Image
                {
                    Name = fileName,
                    ImgUrl = "/Assets/img/" + fileName
                };
                _projectBLL.ImageAdd(image);

                Project newProject = new Project
                {
                    PeopleId = peopleId,
                    Title = project.Title,
                    Description = project.Description,
                    ImageId = _projectBLL.GetLastImageId(),
                    CategoryId = CategoryId,
                    Link = project.Link
                    
                };
                _projectBLL.Add(newProject);

                int lastProjectId = _projectBLL.GetLastProjectId();

                

                foreach (var item in TechnologyId)
                {
                    Project_Technology temp = new Project_Technology();
                    temp.TechnologyId = item;
                    temp.ProjectId = lastProjectId;
                    _projectBLL.Project_TechnologyAdd(temp);
                }

                return Content("<script language='javascript' type='text/javascript'>alert('Proje Başarıyla Eklendi');window.location = '/AdminPanel/Project/Index/';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu !!');window.location = '/AdminPanel/Project/ProjectAdd/';</script>");
            }
        }


        public ActionResult ProjectUpdate(int Id)
        {
            ProjectUpdateModel model = new ProjectUpdateModel();
            model.categoryList = _projectBLL.GetAllCategory();
            model.technologyList = _projectBLL.GetAllTechnology();
            model.project = _projectBLL.Get(Id);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProjectUpdate(Project project, int CategoryId, int[] TechnologyId, HttpPostedFileBase File)
        {
            if (project.Title != null && project.Description != null && CategoryId != 0 && TechnologyId != null)
            {

                
                List<Project_Technology> project_TechnologyList = _projectBLL.GetProject_Technology(project.Id);
                foreach (Project_Technology item in project_TechnologyList)
                {
                    _projectBLL.RemoveProject_Technology(item);
                }

                

                foreach (var item in TechnologyId)
                {
                    Project_Technology temp = new Project_Technology();
                    temp.TechnologyId = item;
                    temp.ProjectId = project.Id;
                    _projectBLL.Project_TechnologyAdd(temp);
                }

                Project updateProject = _projectBLL.Get(project.Id);
                updateProject.Title = project.Title;
                updateProject.Description = project.Description;
                updateProject.CategoryId = CategoryId;
                updateProject.Link = project.Link;

                if (File != null)
                {
                    //SİLME
                    Image deleteImage = _projectBLL.GetImage(_projectBLL.Get(project.Id).ImageId);
                    var fileName2 = deleteImage.Name;
                    var path2 = Path.Combine(Server.MapPath("/Assets/img/"), fileName2);
                    System.IO.File.Delete(path2);


                    //YENİ RESİM EKLEME
                    Image newImage = new Image();
                    var fileName = DateTime.Today.ToLongDateString().Replace(" ", "-") + DateTime.Now.ToLongTimeString().Replace(":", "-") + Path.GetFileName(File.FileName);
                    var path = Path.Combine(Server.MapPath("/Assets/img/"), fileName);
                    File.SaveAs(path);
                    newImage.Name = fileName;
                    newImage.ImgUrl = "/Assets/img/" + fileName;
                    _projectBLL.ImageAdd(newImage);

                    updateProject.ImageId = _projectBLL.GetLastImageId();
                    _projectBLL.Update(updateProject);
                    _projectBLL.RemoveImage(deleteImage);

                    
                }

                _projectBLL.Update(updateProject);

                return Content("<script language='javascript' type='text/javascript'>alert('Proje Başarıyla Güncellendi');window.location = '/AdminPanel/Project/Index/';</script>");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bir Hata Oluştu !!');window.location = '/AdminPanel/Project/Index/';</script>");
            }
            
        }

    }
}