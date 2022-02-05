using Level.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level.Application.Interfaces.Queries
{
    public interface IDeliveryQuery
    {
        Task<IEnumerable<Delivery>> GetAllAsync();
    }
}
