using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository.Abstract
{
    public interface IRepositoryBase<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string[] includes);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
