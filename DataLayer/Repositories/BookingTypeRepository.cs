using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class BookingTypeRepository : RepositoryBase<BookingType> , IBookingTypeRepository
    {
        public BookingTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        { 

        }
    }
}
