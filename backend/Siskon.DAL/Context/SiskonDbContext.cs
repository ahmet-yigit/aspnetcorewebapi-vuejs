using Microsoft.EntityFrameworkCore;
using Siskon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siskon.DAL.Context
{
    public class SiskonDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TREGG5A;Initial Catalog=DbVehicleSiskon;Integrated Security=true");
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
