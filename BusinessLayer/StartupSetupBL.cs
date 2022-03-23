using BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class StartupSetupBL
    {
        public static void AddBusinessServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IReserveService, ReserveService>();
            Services.AddScoped<IBookingTypeService, BookingTypeService>();
            Services.AddScoped<IWorkingDeskService, WorkingDeskService>();
            Services.AddScoped<IRoleService, RoleService>();
            Services.AddScoped<IStateService, StateService>();
            Services.AddScoped<IDeskTypeService, DeskTypeService>();
            Services.AddScoped<ICountryService, CountryService>();
            Services.AddScoped<ICityService, CityService>();
            Services.AddScoped<IMapService, MapService>();
            Services.AddScoped<IOfficeService, OfficeService>();
        }
    }
}
