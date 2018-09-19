using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WorkBLL : IBusiness<Work>
    {
        UnitOfWork _uow;
        public WorkBLL()
        {
            _uow = new UnitOfWork();
        }
        public bool Add(Work item)
        {
            _uow.WorkRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Work Get(int id)
        {
            return _uow.WorkRepository.Get(id);
        }

        public List<Work> GetAll()
        {
            return _uow.WorkRepository.GetAll();
        }
        public int GetPeopleId()
        {
            return _uow.PeopleRepository.GetAll().FirstOrDefault().Id;
        }

        public bool Remove(Work item)
        {
            _uow.WorkRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Work item)
        {
            _uow.WorkRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
