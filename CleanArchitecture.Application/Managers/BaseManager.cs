
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Domain.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Managers
{
    public class BaseManager<TEntity> :  IBaseManager<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        // protected readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public BaseManager(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            // _mapper = mapper;
            _repository = repository;
        }


        public bool Any(Expression<Func<TEntity, bool>> any)
        {
            return _repository.Any(any);
        }
        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> list)
        {
            _repository.AddRange(list);
        }
        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }


        public async Task Delete(object id)
        {
            await _repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public async Task Delete(Expression<Func<TEntity, bool>> where)
        {

            await _repository.Delete(where);
        }

        public void RemoveRange(IEnumerable<TEntity> list)
        {
            _repository.RemoveRange(list);
        }
        public virtual async Task<TEntity> GetById(object id)
        {
            return await _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where)
        {
            var q = _repository.GetSome(where);
            return q;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }




        public virtual async Task<int> AddWithComplete(TEntity entity)
        {
            await AddAsync(entity);
            return await _unitOfWork.Complete();
        }

        public virtual async Task<int> UpdateWithComplete(TEntity entity)
        {
            Update(entity);
            return await _unitOfWork.Complete();
        }



        public virtual async Task<int> DeleteWithComplete(TEntity entity)
        {
            Delete(entity);
            return await _unitOfWork.Complete();
        }








    }
}
