using System.Threading.Tasks;

namespace RallyeTime.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RallyeDbContext context;
        public UnitOfWork(RallyeDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}