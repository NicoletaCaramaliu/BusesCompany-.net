using Proiect_final.Repositories.BusRepository;
using Proiect_final.Services.BusService;

namespace Proiect_final.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository, Repository>();
            services.AddTransient<IBusRepository, BusRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IService,Service>();
            services.AddTransient<IBusService, BusService>();
            return services;
        }
    }
}
