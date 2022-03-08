using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class OfficeRepository : RepositoryBase<Office>, IOfficeRepository
    {
        public OfficeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
