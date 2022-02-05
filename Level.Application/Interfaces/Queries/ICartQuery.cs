using Level.Application.Dto.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level.Application.Interfaces.Queries
{
    public interface ICartQuery
    {
        Task<IEnumerable<CartSum>> GetAllAsync(Guid userId);
    }
}
