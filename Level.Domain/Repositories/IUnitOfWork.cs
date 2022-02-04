using System.Threading.Tasks;

namespace Level.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
