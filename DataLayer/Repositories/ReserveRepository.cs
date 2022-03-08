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

        public bool IsAvailable(DateTime StartDate, DateTime EndDate)
        {
            return true;
        }
    }
}
