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
        }
    }
}
