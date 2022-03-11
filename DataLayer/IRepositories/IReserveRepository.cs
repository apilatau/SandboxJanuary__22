using DataLayer.Models;

namespace DataLayer.IRepositories
{
    public interface IReserveRepository : IRepositoryBase<Reserve>
    {
        public Task<bool> IsAvailable(Reserve reserve,DateTime StartDate, DateTime EndDate);
    }
}
