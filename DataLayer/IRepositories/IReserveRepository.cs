using DataLayer.Models;

namespace DataLayer.IRepositories
{
    public interface IReserveRepository : IRepositoryBase<Reserve>
    {
        public bool IsAvailable(DateTime StartDate, DateTime EndDate);
    }
}
