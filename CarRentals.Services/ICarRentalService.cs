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
    public interface ICarRentalService
    {
        IMapper EntityMapper { get; set; }
        IUnitOfWork UnitOfWrk { get; set; }
        public void ConfigureServiceMappings();
        public void CreateItem(BaseDTO baseDTO);
        public List<BaseDTO> GetItems(Expression<Func<BaseDTO, bool>> filter = null, Func<IQueryable<BaseDTO>, IOrderedQueryable<BaseDTO>> orderBy = null, string includeProperties = "");
    }
}
