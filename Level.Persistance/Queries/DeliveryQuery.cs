using Dapper;
using Level.Application.Interfaces.Queries;
using Level.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Level.Persistance.Queries
{
    public class DeliveryQuery : IDeliveryQuery
    {
        private readonly IDbConnection _connection;

        public DeliveryQuery(IDbConnection connection)
        {
            this._connection = connection;
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            var query = "select c.id, c.minPrice, c.maxPrice, c.price from Delivery c ";

            var result = await _connection.QueryAsync<Delivery>(query);

            return result;

        }
    }
}
