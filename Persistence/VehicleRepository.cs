using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zaap.Models;

namespace Zaap.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ZaapDbContext context;
        public VehicleRepository(ZaapDbContext context)
        {
            this.context = context;

        }
        public async Task<Vehicle> GetVehicle(int id, bool includerelated = true)
        {
            if (includerelated != false)
                return await context.Vehicles.FindAsync(id);
            return await context.Vehicles
                     .Include(v => v.Features)
                     .ThenInclude(vf => vf.Feature)
                     .Include(v => v.Model)
                     .ThenInclude(m => m.Make)
                     .SingleOrDefaultAsync(v => v.Id == id);
        }


        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicleid)
        {
            context.Remove(vehicleid);

        }


    }
}