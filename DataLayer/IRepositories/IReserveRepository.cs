using DataLayer.Models;

namespace DataLayer.IRepositories
{
    public interface IReserveRepository : IRepositoryBase<Reserve>
    {
        public bool IsAvailable(Reserve reserve,DateTime StartDate, DateTime EndDate);
    }
}
