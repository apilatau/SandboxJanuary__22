using DataLayer.Models;

namespace DataLayer.IRepositories
{
    public interface IMapRepository : IRepositoryBase<Map>
    {
        void Update(Map map);
    }
}
