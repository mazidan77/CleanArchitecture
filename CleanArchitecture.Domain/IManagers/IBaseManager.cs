using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IManagers
{
    public interface IBaseManager<TEntity> where TEntity : class
    {
    }
}
