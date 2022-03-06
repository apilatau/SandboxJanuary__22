using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
