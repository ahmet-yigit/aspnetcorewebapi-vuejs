using Siskon.DAL.Abstract;
using Siskon.DAL.Context;
using Siskon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siskon.DAL.Concrete
{
    public class VehicleRepository : IVehicleRepository
    {
        private SiskonDbContext _siskonDbContext = new SiskonDbContext();
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            Vehicle newVehicle = new Vehicle
            {
                Plate = vehicle.Plate,
                Nickname = vehicle.Nickname,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Type = vehicle.Type,
                Color = vehicle.Color,
                State = vehicle.State
            };
            _siskonDbContext.Vehicles.Add(newVehicle);
            _siskonDbContext.SaveChanges();
            return newVehicle;
        }

        public void DeleteVehicle(int id)
        {
            var deleteVehicle = _siskonDbContext.Vehicles.Find(id);
            _siskonDbContext.Vehicles.Remove(deleteVehicle);
            _siskonDbContext.SaveChanges();
        }

        public List<Vehicle> GetAllVehicle()
        {
            return _siskonDbContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _siskonDbContext.Vehicles.Find(id);
        }

        public Vehicle UpdateVehicle(Vehicle vehicle, int id)
        {
            var dgr = _siskonDbContext.Vehicles.FirstOrDefault(x => x.Id == id);
            vehicle.Id = id;
            dgr.Plate = vehicle.Plate;
            dgr.Nickname = vehicle.Nickname;
            dgr.Brand = vehicle.Brand;
            dgr.Model = vehicle.Model;
            dgr.ModelYear = vehicle.ModelYear;
            dgr.Type = vehicle.Type;
            dgr.Color = vehicle.Color;
            dgr.State = vehicle.State;
            _siskonDbContext.SaveChanges();
            return vehicle;
        }
    }
}
