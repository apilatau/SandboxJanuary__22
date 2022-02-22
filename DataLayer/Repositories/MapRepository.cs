using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class MapRepository : RepositoryBase<Map>, IMapRepository
    {
        public MapRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
