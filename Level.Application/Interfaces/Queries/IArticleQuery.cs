using Level.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level.Application.Interfaces.Queries
{
    public interface IArticleQuery
    {
        Task<IEnumerable<Articles>> GetAllAsync();
    }
}
