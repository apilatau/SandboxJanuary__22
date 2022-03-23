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
            return await reserveRepository.AddAsync(reserve);
        }
        
        public string  TestBot()
        {
            return "from reserve service";
        }

        public async Task<Reserve> AddXAsync(Reserve reserve)
        {
            if (reserveRepository.ListAsync().Result.Select(x => x.WorkingDeskId).Contains(reserve.WorkingDeskId))
            {
                throw new ArgumentException("the desk already reserved");
            }
            return await reserveRepository.AddAsync(reserve);
        }

        public async Task<Reserve> AddYAsync(Reserve reserve)
        {
            if (reserveRepository.ListAsync().Result.Where(x => x.EndDate >= reserve.EndDate).Select(x => x.WorkingDeskId).Contains(reserve.WorkingDeskId))
            {
                throw new ArgumentException("the desk already reserved");
            }
            return await reserveRepository.AddAsync(reserve);
        }


        public async Task<Reserve> BookByParameters(int userId, int workingDeskId, DateTime startDate, DateTime endDate, DayOfWeek[] selectedDays, int frequency)
        {
            Reserve reserve = new Reserve();
            if (reserveRepository.ListAsync().Result.Where(x => x.EndDate >= reserve.EndDate).Select(x => x.WorkingDeskId).Contains(reserve.WorkingDeskId))
            {
                throw new ArgumentException("the working desk has been already reserved");
            }
            else
            {
                if (frequency == 0)
                {
                    await reserveRepository.SaveChangesAsync();
                }
                else if (frequency > 0)
                {
                    foreach (DayOfWeek day in selectedDays)
                    {
                        reserve.StartDate = GetNextWeekday(startDate, day);
                        reserve.EndDate = GetNextWeekday(endDate, day);

                        startDate = reserve.StartDate;
                        endDate = reserve.EndDate;
                    }
                    reserve.UserrId = userId;
                    reserve.WorkingDeskId = workingDeskId;

                    await reserveRepository.SaveChangesAsync();
                }
            }
               
            return await reserveRepository.AddAsync(reserve);
        }

        private static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        public async Task<Reserve> AddInAdvanceAsync(Reserve reserve)
        {
            if (reserveRepository.ListAsync().Result.Where(x => x.EndDate >= reserve.EndDate).Select(x => x.WorkingDeskId).Contains(reserve.WorkingDeskId))
            {
                throw new ArgumentException("the working desk has been already reserved");
            }
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

