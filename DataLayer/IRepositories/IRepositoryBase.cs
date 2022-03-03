using DataLayer.Models;
using System.Linq.Expressions;

namespace DataLayer.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> AddMap(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity, CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
    }
}
