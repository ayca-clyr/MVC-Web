using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        KisiselContext _context;
        internal Repository(KisiselContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Entry<T>(item).State = System.Data.Entity.EntityState.Added;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(T item)
        {
            _context.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(T item)
        {
            _context.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
