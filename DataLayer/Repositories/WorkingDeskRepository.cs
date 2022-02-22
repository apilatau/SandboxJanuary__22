using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class WorkingDeskRepository : RepositoryBase<WorkingDesk>, IWorkingDeskRepository
    {
        public WorkingDeskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
