using System.Threading.Tasks;

namespace Zaap.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZaapDbContext context;
        public UnitOfWork(ZaapDbContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}