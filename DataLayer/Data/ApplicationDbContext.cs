using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<WorkingDesk> WorkingDesks { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
