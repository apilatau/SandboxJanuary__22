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
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
