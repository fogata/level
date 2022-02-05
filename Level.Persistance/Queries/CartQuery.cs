using Dapper;
using Level.Application.Dto.Repository;
using Level.Application.Interfaces.Queries;
using Level.Domain.Entities;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Level.Persistance.Queries
{
    public class CartQuery : ICartQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public CartQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public async Task<IEnumerable<CartSum>> GetAllAsync(Guid userId)
        {
            var query = string.Format("select c.id, c.userid, c.articleId, sum(a.price * c.quantity) total from Cart c " +
                "inner join Article a on c.articleId = a.id where c.userid = '{0}' group by c.id, c.userid, c.articleId", userId);

            var result = await _connection.QueryAsync<CartSum>(query);

            return result;

        }
    }
}
