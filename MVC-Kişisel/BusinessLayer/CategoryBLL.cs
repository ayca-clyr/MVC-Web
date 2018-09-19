using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryBLL : IBusiness<Category>
    {
        UnitOfWork _uow;
        public CategoryBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Category item)
        {
            _uow.CategoryRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Category Get(int id)
        {
            return _uow.CategoryRepository.Get(id);
        }

        public List<Category> GetAll()
        {
            return _uow.CategoryRepository.GetAll();
        }

        public bool Remove(Category item)
        {
            _uow.CategoryRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Category item)
        {
            _uow.CategoryRepository.Update(item);
            return _uow.ApplyChanges();
        }

    }
}
