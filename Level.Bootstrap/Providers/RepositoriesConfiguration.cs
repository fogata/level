using Level.Application.Interfaces.Queries;
using Level.Domain.Repositories;
using Level.Persistance.Commands;
using Level.Persistance.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Level.Bootstrap.Providers
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection ConfigureRepositoriesServices(this IServiceCollection services)
        {
            services.AddTransient<ICartRepository, CartCommand>();
            services.AddTransient<IDiscountRepository, DiscountCommand>();

            services.AddTransient<ICartQuery, CartQuery>();
            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IDeliveryQuery, DeliveryQuery>();
            services.AddTransient<IDiscountQuery, DiscountQuery>();

            return services;
        }
    }
}
