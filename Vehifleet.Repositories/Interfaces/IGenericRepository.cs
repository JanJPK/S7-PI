using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vehifleet.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> Get();
        Task<TEntity> GetById(TKey id);
        Task<int> Insert(TEntity entity);
        Task<int> Insert(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task Update(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);
        Task Delete(TKey id);
        Task<bool> Exists(TKey id);
    }
}