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
            Services.AddScoped<IMapService, MapService>();
            Services.AddScoped<IReserveService, ReserveService>();
            Services.AddScoped<IBookingTypeService, BookingTypeService>();
            Services.AddScoped<IWorkingDeskService, WorkingDeskService>();
        }
    }
}
