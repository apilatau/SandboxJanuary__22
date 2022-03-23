using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {

        }
    }
}
