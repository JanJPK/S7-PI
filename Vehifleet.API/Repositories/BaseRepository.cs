using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehifleet.API.DbAccess;

namespace Vehifleet.API.Repositories
{
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public abstract class BaseRepository<TEntity, TKey> where TEntity : class
    {
        protected VehifleetContext Context;

        protected BaseRepository(VehifleetContext context)
        {
            Context = context;
        }

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = DbSet;
        //
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //
        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //
        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public async virtual Task<TEntity> GetById(TKey id)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(id);
        }

        //public virtual void Insert(TEntity entity)
        //{
        //    DbSet.Add(entity);
        //}
        //
        //public async virtual Task<>  DeleteById(TKey id)
        //{
        //    var entity = await GetById(id);
        //    Delete(entityToDelete);
        //}
        //
        //public virtual async Task Delete(TEntity entityToDelete)
        //{
        //    if (Context.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        DbSet.Attach(entityToDelete);
        //    }
        //    return DbSet.Remove(entityToDelete);
        //}
        //
        //public virtual void Update(TEntity entityToUpdate)
        //{
        //    DbSet.Attach(entityToUpdate);
        //    Context.Entry(entityToUpdate).State = EntityState.Modified;
        //}
        //
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await Context.SaveChangesAsync();
        //}
    }
}
