using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        internal DbSet<T> dbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddMap(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Add(entity);
            return entity;
        }

        public async void Delete(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Remove(entity);
        }

        //public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        //{
        //    IQueryable<T> query = dbSet;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    return await query.ToListAsync(cancellationToken: cancellationToken);
        //}

        // DOING
        public Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
