using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProjectBLL : IBusiness<Project>
    {
        UnitOfWork _uow;
        public ProjectBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Project item)
        {
            _uow.ProjectRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Project Get(int id)
        {
            return _uow.ProjectRepository.Get(id);
        }

        public List<Project> GetAll()
        {
            return _uow.ProjectRepository.GetAll();
        }

        public bool Remove(Project item)
        {
            _uow.ProjectRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool RemoveProject_Technology(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public Image GetImage(int id)
        {
            return _uow.ImageRepository.Get(id);
        }

        public bool RemoveImage(Image item)
        {
            _uow.ImageRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public List<Project_Technology> GetProject_Technology(int id)
        {
            return _uow.Project_TechnologyRepository.GetAll().Where(x => x.ProjectId == id).ToList();
        }

        public List<Category> GetAllCategory()
        {
            return _uow.CategoryRepository.GetAll();
        }

        public List<Technology> GetAllTechnology()
        {
            return _uow.TechnologyRepository.GetAll();
        }

        public int GetPeopleId()
        {
            return _uow.PeopleRepository.GetAll().FirstOrDefault().Id;
        }

        public bool Update(Project item)
        {
            _uow.ProjectRepository.Update(item);
            return _uow.ApplyChanges();
        }

        public bool ImageAdd(Image item)
        {
            _uow.ImageRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public int GetLastImageId()
        {
            return _uow.ImageRepository.GetAll().LastOrDefault().Id;
        }

        public int GetLastProjectId()
        {
            return _uow.ProjectRepository.GetAll().LastOrDefault().Id;
        }

        public bool Project_TechnologyAdd(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Add(item);
            return _uow.ApplyChanges();
        }
    }
}
