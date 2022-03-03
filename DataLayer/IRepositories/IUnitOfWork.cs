using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IRepositories
{
    public interface IUnitOfWork
    {
        IBookingTypeRepository BookingTypeRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        IDeskTypeRepository DeskTypeRepository { get; }
        IMapRepository MapRepository { get; }
        IReportRepository ReportRepository { get; }
        IReserveRepository ReserveRepository { get; }
        IRoleRepository RoleRepository { get; }
        IWaitingListRepository WaitingListRepository { get; }
        IWorkingDeskRepository WorkingDeskRepository { get; }
        IOfficeRepository OfficeRepository { get; }

        void Save();
    }
}
