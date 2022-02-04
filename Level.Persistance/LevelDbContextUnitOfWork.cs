using Level.Domain.Repositories;
using System.Threading.Tasks;

namespace Level.Persistance
{
    public class LevelDbContextUnitOfWork : IUnitOfWork
    {
        private readonly LevelDbContext context;

        public LevelDbContextUnitOfWork(LevelDbContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
