using CleanArchitecture.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicatinDbContext _dbContext;

        public Repository( ApplicatinDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public bool Any(Expression<Func<TEntity, bool>> any)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            return query.Any(any);
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange (IEnumerable<TEntity> list)
        {
            _dbContext.Set<TEntity>().AddRange(list);
        }

        public async Task Delete(object id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
        } 
        
        public void Delete(TEntity entity)
        {
         _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(Expression<Func<TEntity,bool>> where)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(where);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> list)
        {
            _dbContext.Set<TEntity>().RemoveRange(list);
        }
        public async Task<TEntity> GetById(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where(where).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;
        }
    }
}
