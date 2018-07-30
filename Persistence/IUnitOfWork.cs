using System.Threading.Tasks;

namespace Zaap.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}