using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.DbAccess;
using Vehifleet.Repositories.Interfaces;

namespace Vehifleet.Repositories
{
    /// <summary>
    ///     Base class for repositories.
    ///     Provides implementation for basic CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <typeparam name="TKey">Entity PK type (usually string or int).</typeparam>
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected VehifleetContext Context;

        public DbSet<TEntity> Set => Context.Set<TEntity>();

        protected GenericRepository(VehifleetContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Get()
        {
            return Set.AsNoTracking();
        }

        public abstract Task<TEntity> GetById(TKey id);

        public virtual async Task<int> Insert(TEntity entity)
        {
            Set.Add(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> Insert(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            Set.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(IEnumerable<TEntity> entities)
        {
            await Set.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            Set.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(TKey id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                Set.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public abstract Task<bool> Exists(TKey id);
    }
}