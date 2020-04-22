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
    public class UserService : BaseService
    {
        private IMapper _entityMapper;
        private IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void CreateItem(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void ConfigureServiceMappings()
        {
            throw new NotImplementedException();
        }

        public override List<BaseDTO> GetItems(Expression<Func<BaseDTO, bool>> filter = null, Func<IQueryable<BaseDTO>, IOrderedQueryable<BaseDTO>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
    }
}
