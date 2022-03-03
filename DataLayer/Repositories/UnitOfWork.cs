using DataLayer.Data;
using DataLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IBookingTypeRepository BookingTypeRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }
        public ICountryRepository CountryRepository { get; private set; }
        public IDeskTypeRepository DeskTypeRepository { get; private set; }
        public IMapRepository MapRepository { get; private set; }
        public IReportRepository ReportRepository { get; private set; }
        public IOfficeRepository OfficeRepository { get; set; }
        public IReserveRepository ReserveRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IWaitingListRepository WaitingListRepository { get; private set; }
        public IWorkingDeskRepository WorkingDeskRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            BookingTypeRepository = new BookingTypeRepository(db);
            CityRepository = new CityRepository(db);
            CountryRepository = new CountryRepository(db);
            OfficeRepository = new OfficeRepository(db);
            DeskTypeRepository = new DeskTypeRepository(db);
            MapRepository = new MapRepository(db);
            ReportRepository = new ReportRepository(db);
            ReserveRepository = new ReserveRepository(db);
            RoleRepository = new RoleRepository(db);
            WaitingListRepository = new WaitingListRepository(db);
            WorkingDeskRepository = new WorkingDeskRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
