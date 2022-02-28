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
    public class WaitingListRepository : RepositoryBase<Waiting>, IWaitingListRepository
    {
        public WaitingListRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
