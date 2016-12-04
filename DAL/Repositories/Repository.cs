using BCRS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    /*
    using of this repository in custom repositories:
        
        public class UsersRepository : Repository<User>, IUserRepository
        
        interface IUserRepository:IRepository<User>
        {
            specific user methods
        }
    */
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IIdentifiable
    {
        public void Add(TEntity entity)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                TEntity entity = GetByIdInternal(context, Id);

                if (entity == null)
                {
                    return;
                }

                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity[] GetAll()
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                return GetEntityQuery(context).ToArray();
            }
        }

        public TEntity GetById(int Id)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                return GetByIdInternal(context, Id);
            }
        }

        public void Update(TEntity entity)
        {
            using (BuildingServiceContext context = new BuildingServiceContext())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        protected virtual IQueryable<TEntity> GetEntityQuery(BuildingServiceContext context)
        {
            return context.Set<TEntity>();
        }

        protected virtual TEntity GetByIdInternal(BuildingServiceContext context, int id)
        {
            return GetEntityQuery(context).FirstOrDefault(e => e.Id == id);
        }
    }
}
