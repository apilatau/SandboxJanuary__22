using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class DeskTypeRepository : RepositoryBase<DeskType>, IDeskTypeRepository
    {
        public DeskTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
