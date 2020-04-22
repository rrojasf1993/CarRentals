using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentals.DAL.UnitOfWork;
using CarRentals.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        internal IUnitOfWork UnitOfWork { get; set; }
        public ICarRentalService BussinessService { get; set; }

        public CarController(IServiceProvider provider)
        {
            this.UnitOfWork=(IUnitOfWork)provider.GetService(typeof(IUnitOfWork));
            this.BussinessService = (CarService)provider.GetService(typeof(ICarRentalService));
        }


        [HttpGet]
        public ActionResult<List<Common.DTO.BaseDTO>> Index()
        {
            try
            {
                var currCars= this.BussinessService.GetItems();
                return Ok(currCars);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpPost("CreateCar")]
        public ActionResult CreateCar(Common.DTO.CarDTO carToCreate)
        {
            try
            {
                this.BussinessService.CreateItem(carToCreate);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }


    }
}