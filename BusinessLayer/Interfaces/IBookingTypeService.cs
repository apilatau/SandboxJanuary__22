using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IBookingTypeService
    {
        Task<BookingType> AddAsync(BookingType bookingType);
        Task DeleteAsync(BookingType bookingType);
        Task<List<BookingType>> ListAsync();
        Task<BookingType> GetByIdAsync(int id);
        Task UpdateAsync(BookingType bookingType);
    }
}
