using DataLayer.Dtos.ReserveDto;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<List<ReserveResponseDto>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);

        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
        public string TestBot();
    }
}