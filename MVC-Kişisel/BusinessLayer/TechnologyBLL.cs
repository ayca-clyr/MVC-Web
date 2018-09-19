using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TechnologyBLL : IBusiness<Technology>
    {
        UnitOfWork _uow;
        public TechnologyBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Technology item)
        {
            _uow.TechnologyRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Technology Get(int id)
        {
            return _uow.TechnologyRepository.Get(id);
        }

        public List<Technology> GetAll()
        {
            return _uow.TechnologyRepository.GetAll();
        }

        public bool Remove(Technology item)
        {
            _uow.TechnologyRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Technology item)
        {
            _uow.TechnologyRepository.Update(item);
            return _uow.ApplyChanges();
        }

        public List<Project_Technology> GetProject_Technology(int id)
        {
            return _uow.Project_TechnologyRepository.GetAll().Where(x => x.TechnologyId == id).ToList();
        }

        public bool Project_TechnologyRemove(Project_Technology item)
        {
            _uow.Project_TechnologyRepository.Remove(item);
            return _uow.ApplyChanges();
        }
    }
}
