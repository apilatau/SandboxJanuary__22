using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dtos.ReserveDto;
using DataLayer.Models;
using DataLayer.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class ReserveService : IReserveService
    {
        private readonly ReserveRepository ReserveRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<Reserve> dbSet;

        public ReserveService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<Reserve>();
        }

        public async Task<List<ReserveResponseDto>> GetAllReserves(int id, CancellationToken cancellationToken = default)
        {
            List<ReserveResponseDto> reserves = await dbSet
                .Select(m => m.Adapt<ReserveResponseDto>())
                .Where(m => m.UserId == id)
                .ToListAsync(cancellationToken);
            return reserves;
        }
    }
}
