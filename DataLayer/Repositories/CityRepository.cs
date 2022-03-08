using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            
        }
    }
}
