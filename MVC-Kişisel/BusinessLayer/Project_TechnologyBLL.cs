using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Project_TechnologyBLL : IBusiness<Project_Technology>
    {
        UnitOfWork _uow;
        public Project_TechnologyBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Project_Technology Get(int id)
        {
            return _uow.Project_TechnologyRepository.Get(id);
        }

        public List<Project_Technology> GetAll()
        {
            return _uow.Project_TechnologyRepository.GetAll();
        }

        public bool Remove(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
