using Level.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level.Application.Interfaces.Queries
{
    public interface ICartQuery
    {
        Task<IEnumerable<Cart>> GetAllAsync(Guid userId);
    }
}
