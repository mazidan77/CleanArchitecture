using CleanArchitecture.Domain.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastrucure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicatinDbContext _db { get; set; }
        private IDbContextTransaction _transaction;
        public UnitOfWork(ApplicatinDbContext context)
        {
            _db = context;
                
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }
        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }
        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task DisposeTransaction()
        {
            await _transaction.DisposeAsync();
        }
        public bool IsTransactionStarted()
        {
            return _transaction != null;
        }
        public async Task<int> ExecuteQuery(string query)
        {
            return await _db.Database.ExecuteSqlRawAsync(query);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<int> ExecuteSqlCommand(FormattableString query)
        {
            return await _db.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}
