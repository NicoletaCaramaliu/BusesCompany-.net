using Proiect_final.Data.UnitOfWork;
using Proiect_final.Repositories.AdressRepository;
using Proiect_final.Repositories.BusRepository;
using Proiect_final.Repositories.DefectionRepository;
using Proiect_final.Repositories.DriverRepository;
using Proiect_final.Repositories.RepairHistoryRepository;
using Proiect_final.Services.AdressService;
using Proiect_final.Services.BusService;
using Proiect_final.Services.DefectionService;
using Proiect_final.Services.DriverService;
using Proiect_final.Services.RepairHistoryService;

namespace Proiect_final.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository, Repository>();
            services.AddTransient<IBusRepository, BusRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IAdressRepository, AdressRepository>();
            services.AddTransient<IDefectionRepository, DefectionRepository>();
            services.AddTransient<IRepairHistoryRepository, RepairHistoryRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IService,Service>();
            services.AddTransient<IBusService, BusService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IAdressService, AdressService>();
            services.AddTransient<IDefectionService, DefectionService>();
            services.AddTransient<IRepairHistoryService, RepairHistoryService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
