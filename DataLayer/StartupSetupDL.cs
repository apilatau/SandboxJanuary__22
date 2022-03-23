using DataLayer.IRepositories;
using DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class StartupSetupDL
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReserveRepository, ReserveRepository>();
            services.AddTransient<IBookingTypeRepository, BookingTypeRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IWorkingDeskRepository, WorkingDeskRepository>();
            services.AddTransient<IWorkingDeskRepository, WorkingDeskRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IMapRepository, MapRepository>();
            services.AddTransient<IStateRepository, StateRepository>();

        }
    }
}
