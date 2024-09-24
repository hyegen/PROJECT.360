using PROJECT._360.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.CORE.DataAccess.EntityFramework
{
    public class EfGenericRepositoryBase<TEntity, TContext>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        #region generic crud methods
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var genericAdd = context.Entry(entity);
                genericAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var genericAdd = context.Entry(entity);
                genericAdd.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var genericAdd = context.Entry(entity);
                genericAdd.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        #endregion
    }
}
