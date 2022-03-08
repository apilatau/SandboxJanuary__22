using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
