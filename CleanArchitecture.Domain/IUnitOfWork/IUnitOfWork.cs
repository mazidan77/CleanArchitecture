using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task DisposeTransaction();
        Task<int> ExecuteQuery(string query);
        Task<int> ExecuteSqlCommand(FormattableString query);
    }
}
