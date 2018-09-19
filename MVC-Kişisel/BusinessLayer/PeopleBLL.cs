using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PeopleBLL : IBusiness<People>
    {
        UnitOfWork _uow;
        public PeopleBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(People item)
        {
            _uow.PeopleRepository.Add(item);
            return _uow.ApplyChanges();
        }
        public bool ImageAdd(Image item)
        {
            _uow.ImageRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public List<Category> GetCategoryList()
        {
            return _uow.CategoryRepository.GetAll();
        }

        public People Get(int id)
        {
            return _uow.PeopleRepository.Get(id);
        }
       

        public List<People> GetAll()
        {
            return _uow.PeopleRepository.GetAll();
        }

        public Image GetImage()
        {
            return _uow.ImageRepository.GetAll().LastOrDefault();
        }
        public Image GetImageForId(int id)
        {
            return _uow.ImageRepository.Get(id);
        }

        public bool Remove(People item)
        {
            _uow.PeopleRepository.Remove(item);
            return _uow.ApplyChanges();
        }
        public bool RemoveImage(Image item)
        {
            _uow.ImageRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(People item)
        {
            _uow.PeopleRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
