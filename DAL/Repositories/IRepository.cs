using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IIdentifiable
    {
        void Add(TEntity entity);
        TEntity GetById(int Id);
        void Update(TEntity entity);
        void Delete(int Id);
        TEntity[] GetAll();
    }
}
