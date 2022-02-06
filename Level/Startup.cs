using Level.Presenters.Interfaces;
using Level.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Level.Bootstrap;

namespace Level
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices(Configuration);

            services.AddTransient<IBasePresenter, BasePresenter>();
            services.AddTransient<ICartPresenter, CartPresenter>();
            services.AddTransient<IDiscountPresenter, DiscountPresenter>();
            services.AddTransient<IArticlePresenter, ArticlePresenter>();
            services.AddTransient<IDeliveryPresenter, DeliveryPresenter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
            app.Configure(configuration);
        }
    }
}
