using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siskon.BLL.Abstract;
using Siskon.BLL.Concrete;
using Siskon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siskon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;
        public VehicleController()
        {
            _vehicleService = new VehicleManager();
        }

        [HttpGet]
        public List<Vehicle> Get()
        {
            return _vehicleService.GetAllVehicle();
        }
        [HttpGet("{id}")]
        public Vehicle Get(int id)
        {
            return _vehicleService.GetVehicleById(id);
        }
        [HttpPost]
        public Vehicle Post([FromBody] Vehicle vehicle)
        {
            return _vehicleService.CreateVehicle(vehicle);
        }
        [HttpPut("{id}")]
        public Vehicle Put([FromBody] Vehicle vehicle, int id)
        {
            return _vehicleService.UpdateVehicle(vehicle, id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleService.DeleteVehicle(id);
        }
    }
}
