using Level.Bootstrap.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Level.Bootstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Level", Version = "v1" });
            });
            services.AddCors();
            services.ConfigureMVCServices();
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureMediatrServices();
            services.ConfigureRepositoriesServices();
            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseRequestLocalization();
            app.UsePathBase(configuration.GetValue<string>("BasePath"));
            app.UseCors();
            app.ConfigureMVC();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Level v1"));
            var localizeOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOptions.Value);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
