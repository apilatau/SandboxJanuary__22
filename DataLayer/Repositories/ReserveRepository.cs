using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ReserveRepository : RepositoryBase<Reserve>, IReserveRepository
    {
        private readonly ApplicationDbContext _context;
        public ReserveRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public bool IsAvailable(Reserve reserve, DateTime StartDate, DateTime EndDate)
        {
            var currentBooking = _context.Reserves.Where(x => x.WorkingDeskId == reserve.WorkingDeskId)
                                                  .Select(x => x.StartDate <= StartDate && x.EndDate <= EndDate)
                                                  .FirstOrDefault();
            return currentBooking;
        }
    }
}
