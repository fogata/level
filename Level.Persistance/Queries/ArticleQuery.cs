using Level.Application.Interfaces.Queries;
using Level.Domain.Entities;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Level.Persistance.Queries
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public ArticleQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this._connection = connection;
            this._sqlKataCompiler = sqlKataCompiler;
        }

        public async Task<IEnumerable<Articles>> GetAllAsync()
        {
            var queryFactory = new QueryFactory(_connection, _sqlKataCompiler);
            var query = queryFactory
                .Query("Article");
            return await query.GetAsync<Articles>();
        }
    }
}
