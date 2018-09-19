using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SocialBLL : IBusiness<Social>
    {
        UnitOfWork _uow;
        public SocialBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Social item)
        {
            _uow.SocialRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Social Get(int id)
        {
            return _uow.SocialRepository.Get(id);
        }

        public List<Social> GetAll()
        {
            return _uow.SocialRepository.GetAll();
        }

        public int GetPeopleId()
        {
            return _uow.PeopleRepository.GetAll().FirstOrDefault().Id;
        }

        public bool Remove(Social item)
        {
            _uow.SocialRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Social item)
        {
            _uow.SocialRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
