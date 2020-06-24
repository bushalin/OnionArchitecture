using Microsoft.EntityFrameworkCore;
using Onion.API.Model;
using Onion.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly OnionApiDbContext _context;
        private DbSet<T> entities;
        private string errorMessage = string.Empty;

        public GenericRepository(OnionApiDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Delete(Guid id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(Guid id);

        void SaveChanges();
    }
}