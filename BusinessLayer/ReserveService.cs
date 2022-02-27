using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;

namespace BusinessLayer
{
    public class ReserveService : IReserveService
    {
        private AppSettings _appSettings;
        private readonly IReserveRepository reserveRepository;

        public ReserveService(IReserveRepository reserveRepository)
        {
            this.reserveRepository = reserveRepository;
            _appSettings = new AppSettings();
        }

        public async Task<Reserve> AddAsync(Reserve reserve)
        {
            return await reserveRepository.AddAsync(reserve);
        }

        public async Task DeleteAsync(Reserve reserve) =>  await reserveRepository.DeleteAsync(reserve);
        

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
