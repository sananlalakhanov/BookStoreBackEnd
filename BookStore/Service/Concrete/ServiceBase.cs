using BookStore.Repository.Abstract;
using BookStore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Service.Concrete
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public IEnumerable<T> GetAll()
        {
            //return _repository.GetAll();
            return _repository.GetAll();
        }

        public IEnumerable<T> GetAll(string[] includes)
        {
            return _repository.GetAll(includes);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
    }
}
