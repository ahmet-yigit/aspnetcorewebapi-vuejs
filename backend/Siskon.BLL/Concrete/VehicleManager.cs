using Siskon.BLL.Abstract;
using Siskon.DAL.Abstract;
using Siskon.DAL.Concrete;
using Siskon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siskon.BLL.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;
        public VehicleManager()
        {
            _vehicleRepository = new VehicleRepository();
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.CreateVehicle(vehicle);
        }

        public void DeleteVehicle(int id)
        {
            _vehicleRepository.DeleteVehicle(id);
        }

        public List<Vehicle> GetAllVehicle()
        {
            return _vehicleRepository.GetAllVehicle();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }

        public Vehicle UpdateVehicle(Vehicle vehicle, int id)
        {
            return _vehicleRepository.UpdateVehicle(vehicle,id);
        }
    }
}
