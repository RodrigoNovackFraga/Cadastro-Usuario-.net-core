using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Model.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerContext _sqlServerContext;

        public BaseRepository(SqlServerContext mySqlContext)
        {
            _sqlServerContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _sqlServerContext.Set<TEntity>().Add(obj);
            _sqlServerContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlServerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlServerContext.Set<TEntity>().Remove(Select(id));
            _sqlServerContext.SaveChanges();
        }

        public IList<TEntity> Select() => _sqlServerContext.Set<TEntity>().ToList();

        public TEntity Select(int id) => _sqlServerContext.Set<TEntity>().Find(id);

    }
}
