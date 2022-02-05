using Level.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level.Application.Interfaces.Queries
{
    public interface IDiscountQuery
    {
        Task<IEnumerable<Discount>> GetAllAsync(Guid userId);
    }
}
