using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookingTypeService : IBookingTypeService
    {
        private AppSettings _appSettings;
        private readonly IBookingTypeRepository bookingTypeRepository;

        public BookingTypeService(IBookingTypeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
            _appSettings = new AppSettings();
        }
        public async Task<BookingType> AddAsync(BookingType bookingType)
        {
            return await bookingTypeRepository.AddAsync(bookingType);   
        }

        public async Task DeleteAsync(BookingType bookingType) => await bookingTypeRepository.DeleteAsync(bookingType);

        public async Task<BookingType> GetByIdAsync(int id)
        {
            return await bookingTypeRepository.GetByIdAsync(id);
        }

        public Task<List<BookingType>> ListAsync()
        {
            return bookingTypeRepository.ListAsync();
        }

        public async Task UpdateAsync(BookingType bookingType) => await bookingTypeRepository.UpdateAsync(bookingType);
    }
}
