using CarRentals.DAL.Entities;
using CarRentals.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Car> Cars { get;  }
        public IGenericRepository<User> Users { get; }
        public CarRentalsContext Context { get; set; }
        public void SaveChanges();


    }
}
