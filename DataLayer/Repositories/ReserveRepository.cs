using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ReserveRepository : RepositoryBase<Reserve>, IReserveRepository
    {
        private readonly ApplicationDbContext _context;
        public ReserveRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> IsAvailable(Reserve reserve, DateTime StartDate, DateTime EndDate)
        {
            var currentBooking = await _context.Reserves.Where(x => x.WorkingDeskId == reserve.WorkingDeskId)
                                                  .Select(x => x.StartDate <= StartDate && x.EndDate <= EndDate)
                                                  .FirstOrDefaultAsync();
            return currentBooking;
        }
    }
}
