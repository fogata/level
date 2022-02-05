using Level.Domain.Entities;
using System.Threading.Tasks;

namespace Level.Domain.Repositories
{
    public  interface IDiscountRepository
    {
        Task<Discount> InsertAsync(Discount value);
        void Delete(Discount value);
    }
}
