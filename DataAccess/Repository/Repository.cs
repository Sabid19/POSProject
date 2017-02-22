using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<TEntity> : IRepository.IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        ASITPOSDBEntities Db = new ASITPOSDBEntities();

        public Repository()
        {
            Context = Db;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Db.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);

        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
           return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Update(TEntity original, TEntity NewEntity)
        {
            Context.Entry<TEntity>(original).CurrentValues.SetValues(NewEntity);
            Db.SaveChanges();
        }
    }
}
