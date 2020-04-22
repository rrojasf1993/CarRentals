using AutoMapper;
using CarRentals.Common.DTO;
using CarRentals.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRentals.Services
{
    public abstract class BaseService : ICarRentalService
    {
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWrk = unitOfWork;
        }
        public IMapper EntityMapper { get; set; }
        public IUnitOfWork UnitOfWrk { get; set; }
        public abstract void ConfigureServiceMappings();
        public abstract void CreateItem(BaseDTO baseDTO);
        public abstract List<BaseDTO> GetItems(Expression<Func<BaseDTO, bool>> filter = null, Func<IQueryable<BaseDTO>, IOrderedQueryable<BaseDTO>> orderBy = null, string includeProperties = "");
    }
}
