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
                .Query("Beneficiaries as B")
                .Select
                (
                    "B.Id",
                    "B.UserPersonId",
                    "B.AccountId",
                    "B.PersonId",
                    "B.Name",
                    "B.FirstName",
                    "B.MiddleName",
                    "B.LastName",
                    "B.Document",
                    "B.DocumentType",
                    "B.Phone",
                    "B.Alias",
                    "B.Country",
                    "B.CompanyName",
                    "A.Id",
                    "A.AccountId",
                    "A.AccountNumber",
                    "A.BankName",
                    "A.BankNumber",
                    "A.Branch",
                    "A.Type",
                    "A.IsExternal",
                    "A.BeneficiaryId"
                )
                .Join("Accounts as A", "B.Id", "A.BeneficiaryId")
                .Where("B.UserPersonId", userId);

            var sqlResult = _sqlKataCompiler.Compile(query);

            var result = await _connection.QueryAsync<Cart, ArticleItem, Articles>
                 (
                  sqlResult.Sql,
                 (cart, item) =>
                 {
                     cart.items = item;

                     return cart;
                 },
                param: sqlResult.NamedBindings);

            return result;
        }
    }
}
