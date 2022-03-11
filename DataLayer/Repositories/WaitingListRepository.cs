using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class WaitingListRepository : RepositoryBase<Waiting>, IWaitingListRepository
    {
        public WaitingListRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
