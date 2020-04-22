using CarRentals.DAL.Entities;
using CarRentals.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.DAL.UnitOfWork
{
    public class CarRentalsUnitOfWork : IUnitOfWork
    {
		private IGenericRepository<Car> _cars;
		private IGenericRepository<User> _users;
		private CarRentalsContext _context;


		public CarRentalsUnitOfWork(CarRentalsContext carRentalsContext)
		{
			this.Context = carRentalsContext;
		}


		public IGenericRepository<Car> Cars
		{
			get
			{
				return _cars ??  (_cars = new BaseRepository<Car>(_context));
			}
			
		}

		public IGenericRepository<User> Users
		{
			get 
			{
				return _users ?? (_users = new BaseRepository<User>(_context));
			}
		}

		public CarRentalsContext Context
		{
			get { return _context; }
			set { _context = value; }
		}

		public void SaveChanges()
		{
			this.Context.SaveChanges();
		}

    }
}
