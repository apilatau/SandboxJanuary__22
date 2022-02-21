using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
