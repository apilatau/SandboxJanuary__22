using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IStateService
    {
        Task<State> AddAsync(State state);
        Task DeleteAsync(State state);
        Task<List<State>> CurrentListOfStates();
        Task<State> GetByIdAsync(int id);
        Task UpdateAsync(State state);
    }
}
