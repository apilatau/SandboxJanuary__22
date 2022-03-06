﻿using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;

namespace BusinessLayer
{
    public class ReserveService : IReserveService
    {
        private readonly IReserveRepository reserveRepository;

        public ReserveService(IReserveRepository reserveRepository)
        {
            this.reserveRepository = reserveRepository;
        }

        public async Task<Reserve> AddAsync(Reserve reserve)
        {
            return await reserveRepository.AddAsync(reserve);
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
