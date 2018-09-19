using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SkillBLL : IBusiness<Skill>
    {
        UnitOfWork _uow;
        public SkillBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Skill item)
        {
            _uow.SkillRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Skill Get(int id)
        {
            return _uow.SkillRepository.Get(id);
        }

        public List<Skill> GetAll()
        {
            return _uow.SkillRepository.GetAll();
        }

        public int GetPeopleId()
        {
            return _uow.PeopleRepository.GetAll().FirstOrDefault().Id;
        }

        public bool Remove(Skill item)
        {
            _uow.SkillRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Skill item)
        {
            _uow.SkillRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
