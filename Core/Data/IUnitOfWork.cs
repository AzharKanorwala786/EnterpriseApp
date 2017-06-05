using System;
using Core.Data.Repositories;
using Core.Entities.Foundation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
  public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void BeginTransaction();

        void Commit();

        Task<int> CommitAsync();

        void RollBack();

        void Dispose(bool disposing);

    }
}
