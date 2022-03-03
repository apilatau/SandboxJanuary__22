using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class MapRepository : RepositoryBase<Map>, IMapRepository
    {
        private ApplicationDbContext _db;
        public MapRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        void IMapRepository.Update(Map map)
        {
            _db.Maps.Update(map);
        }
    }
}
