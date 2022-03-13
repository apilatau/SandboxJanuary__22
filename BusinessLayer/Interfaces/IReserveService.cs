namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<List<Reserve>> GetAllReserves(int id = default);

        Task<List<Reserve>> GetReservesForEachEmployee(List<Reserve> reserves);
        Task<Reserve> GetByIdAsync(int id);
    }
}