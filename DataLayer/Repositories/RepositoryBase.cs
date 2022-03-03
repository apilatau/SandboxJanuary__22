using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbSet;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await dbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await dbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Update(entity);

            await SaveChangesAsync(cancellationToken);
        }
    }
}
