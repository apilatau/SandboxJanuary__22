using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class ReserveService : IReserveService
    {
        private readonly IReserveRepository reserveRepository;


        public ReserveService(ApplicationDbContext dbContext, IReserveRepository reserveRepository)
        {
            this.reserveRepository = reserveRepository;
        }

        public async Task<List<Reserve>> GetAllReserves(int id, CancellationToken cancellationToken = default)
        {

            var list = await reserveRepository.ListAsync();


            return list.Where(x => x.Id == id).ToList();
        }

        public async Task<Reserve> AddAsync(Reserve reserve)
        {
            if (await reserveRepository.IsAvailable(reserve, reserve.StartDate, reserve.EndDate))
            {
                throw new ArgumentException("the desk already reserved");
            }
            return await reserveRepository.AddAsync(reserve);
        }


        public async Task EditBookingForUserAsync(int booking_id, int userId, Reserve reserve)
        {

            var booking = await reserveRepository.GetByIdAsync(booking_id);
            var isAvailable = await reserveRepository.IsAvailable(reserve, booking.StartDate, booking.EndDate);

            if (!isAvailable) throw new ArgumentException("These dates are not availbale");

            if (booking.UserId != userId)
            {
                booking.StartDate = reserve.StartDate;
                booking.EndDate = reserve.EndDate;
                booking.BookingType = reserve.BookingType;
                booking.Frequency = reserve.Frequency;

                await reserveRepository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("You have not authorized to edit this booking");
            }

        }

        public async Task<Reserve> AddInAdvanceAsync(Reserve reserve)
        {
            if (reserve.EndDate > DateTime.Now.AddMonths(3) || reserve.EndDate < DateTime.Now)
            {
                throw new ArgumentException("The workspace had already been reserved or " +
                    "you can only reserve workspace as late as 3 months before your employment date.");
            }
            return await reserveRepository.AddAsync(reserve);
        }

        public async Task DeleteAsync(Reserve reserve) => await reserveRepository.DeleteAsync(reserve);


        public async Task<Reserve> GetByIdAsync(int id)
        {
            return await reserveRepository.GetByIdAsync(id);
        }

        public async Task<List<Reserve>> ListAsync()
        {
            return await reserveRepository.ListAsync();
        }

        public async Task UpdateAsync(Reserve reserve) => await reserveRepository.UpdateAsync(reserve);
    }
}

