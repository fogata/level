using Dapper;
using Level.Application.Interfaces.Queries;
using Level.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Level.Persistance.Queries
{
    public class DiscountQuery : IDiscountQuery
    {
        private readonly IDbConnection _connection;
     

        public DiscountQuery(IDbConnection connection)
        {
            this._connection = connection;
        }

        public async Task<IEnumerable<Discount>> GetAllAsync(Guid userId)
        {
            var query = string.Format("SELECT [id],[articleId],[userId],[type],[total] " +
            "FROM[dbo].[Discount] Where userId = '{0}'", userId);
            var result = await _connection.QueryAsync<Discount>(query);
            return result;

        }
    }
}
