using Proiect_final.Repositories.BusRepository;
using Proiect_final.Repositories.DriverRepository;
using Proiect_final.Services.BusService;
using Proiect_final.Services.DriverService;

namespace Proiect_final.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository, Repository>();
            services.AddTransient<IBusRepository, BusRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IService,Service>();
            services.AddTransient<IBusService, BusService>();
            services.AddTransient<IDriverService, DriverService>();
            return services;
        }
    }
}
