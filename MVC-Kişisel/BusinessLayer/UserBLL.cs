using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBLL : IBusiness<User>
    {
        UnitOfWork _uow;
        public UserBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(User item)
        {
            _uow.UserRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public User Get(int id)
        {
            return _uow.UserRepository.Get(id);
        }

        public List<User> GetAll()
        {
            return _uow.UserRepository.GetAll();
        }

        public bool Remove(User item)
        {
            _uow.UserRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(User item)
        {
            _uow.UserRepository.Update(item);
            return _uow.ApplyChanges();
        }

        public User LoginUser(string username, string password)
        {
            return GetAll().Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
        }
    }
}
