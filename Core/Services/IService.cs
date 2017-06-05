using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
   public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
