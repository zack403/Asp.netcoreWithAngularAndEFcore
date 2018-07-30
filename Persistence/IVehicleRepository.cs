using System.Threading.Tasks;
using Zaap.Models;

namespace Zaap.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includerelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicleid);
    }
}