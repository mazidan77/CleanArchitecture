using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepositories
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> list);
        Task Delete(object id);

        void Delete(T entity);
        Task Delete(Expression<Func<T, bool>> where);

        Task<T> GetById(object id);

        IEnumerable<T> GetSome(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();

        void RemoveRange(IEnumerable<T> list);

        void Update(T entity);
    }
}
