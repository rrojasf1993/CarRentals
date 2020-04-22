using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
namespace CarRentals.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> Get( Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "");

        TEntity GetById(Int32 id);

        void Add(TEntity entityToAdd);
        void Delete(TEntity entityToRemove);

        void DeleteById(Int32 id);

        void Update(TEntity entityToUpdate);
    }
}
