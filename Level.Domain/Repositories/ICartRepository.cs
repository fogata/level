using Level.Domain.Entities;
using System.Threading.Tasks;

namespace Level.Domain.Repositories
{
    public  interface ICartRepository
    {
        Task<Cart> InsertAsync(Cart value);
        void Delete(Cart value);
    }
}
