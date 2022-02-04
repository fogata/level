using Level.Domain.Repositories;
using Level.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

namespace Level.Bootstrap.Providers
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {
            var connectionString = configuration.GetConnectionString("level");

            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b => new SqlConnection(connectionString));

            services.AddDbContextPool<LevelDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, LevelDbContextUnitOfWork>();

            services.AddStartupTask<LevelDbContext>(context => context.Database.MigrateAsync());

            //Adding SqlServer example
            if (addHealthCheck)
            {
                services.AddHealthChecks()
                    .AddSqlServer(connectionString, "SELECT 1;", tags: new string[] { "db", "sqlserver" });
            }

            return services;
        }
    }
}
