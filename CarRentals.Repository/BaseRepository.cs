using CarRentals.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRentals.Repository
{
   public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
   {

        internal CarRentalsContext carRentalsContext;
        private DbSet<TEntity> _currEntity;

        internal CarRentalsContext CarRentalsContext
        {
            get { return carRentalsContext; }
            set { carRentalsContext = value; }
        }

        internal DbSet<TEntity> CurrEntity
        {
            get { return _currEntity; }
            set { _currEntity = value; }
        }

        public BaseRepository(CarRentalsContext context)
        {
            this.CarRentalsContext = context;
            this.CurrEntity = this.carRentalsContext.Set<TEntity>();
        }


        public void Add(TEntity entityToAdd)
        {
            this.CurrEntity.Add(entityToAdd);
        }

        public void Delete(TEntity entityToRemove)
        {
            if (this.CarRentalsContext.Entry(entityToRemove).State == EntityState.Detached)
            {
                this.CurrEntity.Attach(entityToRemove);
            }
            this.CurrEntity.Remove(entityToRemove);
        }

        public virtual void DeleteById(int id)
        {
            TEntity entityToRemove= this.CurrEntity.Find(id);
            Delete(entityToRemove);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.CurrEntity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(int id)
        {
            return this.CurrEntity.Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.CarRentalsContext.Attach(entityToUpdate);
            this.CarRentalsContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
