using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ReserveRepository : RepositoryBase<Reserve>, IReserveRepository
    {
        public ReserveRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
