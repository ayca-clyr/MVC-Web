using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ImageBLL : IBusiness<Image>
    {
        UnitOfWork _uow;
        public ImageBLL()
        {
            _uow = new UnitOfWork();
        }

        public bool Add(Image item)
        {
            _uow.ImageRepository.Add(item);
            return _uow.ApplyChanges();
        }

        public Image Get(int id)
        {
            return _uow.ImageRepository.Get(id);
        }

        public List<Image> GetAll()
        {
            return _uow.ImageRepository.GetAll();
        }

        public bool Remove(Image item)
        {
            _uow.ImageRepository.Remove(item);
            return _uow.ApplyChanges();
        }

        public bool Update(Image item)
        {
            _uow.ImageRepository.Update(item);
            return _uow.ApplyChanges();
        }
    }
}
