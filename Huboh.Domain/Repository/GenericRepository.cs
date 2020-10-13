using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;

namespace Huboh.Domain.Repository
{
    public class GenericRepository<T> : IDataRepository<T> where T : class
    {
        private DbContext _context = null;
        private DbSet<T> _table = null;

        public GenericRepository(DbContext context = null)
        {
            this._context = context;
            _table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public bool Insert(T obj)
        {
            try
            {
                _table.Add(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T existing = _table.Find(id);
                _table.Remove(existing);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
