using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EducationBLL : IBusiness<Education>
    {
        UnitOfWork _uow;
        public EducationBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Education item)
        {
            _uow.EducationRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Education Get(int id)
        {
            return _uow.EducationRepository.Get(id);
        }

        public List<Education> GetAll()
        {
            return _uow.EducationRepository.GetAll();
        }
        public int GetPeopleId()
        {
            return _uow.PeopleRepository.GetAll().FirstOrDefault().Id;
        }

        public bool Remove(Education item)
        {
            _uow.EducationRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Education item)
        {
            _uow.EducationRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
