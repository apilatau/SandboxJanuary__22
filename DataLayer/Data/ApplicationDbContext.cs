using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reserv> Reservs { get; set; }
        public DbSet<WorkingDesk> WorkingDesks { get; set; }

    }
}
