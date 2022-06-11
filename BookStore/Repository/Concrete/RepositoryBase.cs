using BookStore.Data.EntityFramework;
using BookStore.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly BookStoreDbContext _context;
        private DbSet<T> table = null;

        public RepositoryBase(BookStoreDbContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public IEnumerable<T> GetAll(string[] includes)
        {
            var query = table.AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            //return query;
          //  var res = includes.Aggregate(table.AsQueryable(), (query, path) => query.Include(path));
            return query.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }        

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
