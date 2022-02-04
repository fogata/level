using Dapper;
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

        public async Task<IEnumerable<Cart>> GetAllAsync(Guid userId)
        {
            var queryFactory = new QueryFactory(_connection, _sqlKataCompiler);
            var query = queryFactory
                .Query("ArticleItem as B")
                .Select
                (
                    "B.id",
                    "B.cartId",
                    "B.articleId",
                    "B.quantity",
                    "B.discountType",
                    "B.discount"
                )
                .Join("Cart as A", "B.cartId", "A.id");
                //.Where("A.userId", userId);

            var sqlResult = _sqlKataCompiler.Compile(query);

            var result = await _connection.QueryAsync<Cart>(sqlResult.Sql);

            return result;

        }
    }
}
