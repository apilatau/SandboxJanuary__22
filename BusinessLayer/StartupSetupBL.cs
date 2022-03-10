using BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class StartupSetupBL
    {
        public static void AddBusinessServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IMapService, MapService>();
            Services.AddScoped<IReserveService, ReserveService>();
            Services.AddScoped<IBookingTypeService, BookingTypeService>();
            Services.AddScoped<IWorkingDeskService, WorkingDeskService>();
            Services.AddScoped<IOfficeService, OfficeService>();
            Services.AddScoped<IRoleService, RoleService>();
        }
    }
}
