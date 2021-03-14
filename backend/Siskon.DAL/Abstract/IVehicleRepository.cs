using Siskon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siskon.DAL.Abstract
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicle();
        Vehicle GetVehicleById(int id);
        Vehicle CreateVehicle(Vehicle vehicle);
        Vehicle UpdateVehicle(Vehicle vehicle, int id);
        void DeleteVehicle(int id);
    }
}
