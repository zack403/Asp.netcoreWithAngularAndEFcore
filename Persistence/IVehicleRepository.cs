using System.Threading.Tasks;
using Zaap.Models;

namespace Zaap.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
    }
}