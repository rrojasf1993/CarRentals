using CarRentals.Common.DTO;
using CarRentals.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;

namespace CarRentals.Services
{
    public class CarService : BaseService
    {
        public CarService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            ConfigureServiceMappings();
        }

        public override void ConfigureServiceMappings()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<DAL.Entities.Car, Common.DTO.CarDTO>();
                  cfg.CreateMap<CarDTO, DAL.Entities.Car>();
              });
            mapperConfig.AssertConfigurationIsValid();
            this.EntityMapper = mapperConfig.CreateMapper();
        }

        public override void CreateItem(BaseDTO carToCreate)
        {
            try
            {
                DAL.Entities.Car carToInsert = new DAL.Entities.Car();
                this.EntityMapper.Map(carToCreate, carToInsert);
                this.UnitOfWrk.Cars.Add(carToInsert);
                this.UnitOfWrk.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public override List<BaseDTO> GetItems(Expression<Func<BaseDTO, bool>> filter = null, Func<IQueryable<BaseDTO>, IOrderedQueryable<BaseDTO>> orderBy = null, string includeProperties = "")
        {
            IEnumerable<BaseDTO> carInstances = null;
            try
            {
                var currentItems = this.UnitOfWrk.Cars.Get();
                carInstances = (IEnumerable<CarDTO>)this.EntityMapper.Map(currentItems, typeof(IEnumerable<DAL.Entities.Car>), typeof(IEnumerable<CarDTO>));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return carInstances.ToList();
        }
    }
}
