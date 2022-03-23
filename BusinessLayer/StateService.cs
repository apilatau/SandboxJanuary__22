using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _statrepository;

        public StateService(IStateRepository statrepository)
        {
            _statrepository = statrepository;
        }

        public async Task<State> AddAsync(State state)
        {
            return await _statrepository.AddAsync(state);   
        }

        public async Task DeleteAsync(State state) => await _statrepository.DeleteAsync(state);

        public async Task<State> GetByIdAsync(int id)
        {
            return await _statrepository.GetByIdAsync(id);
        }

        public async Task<List<State>> CurrentListOfStates()
        {
            return await _statrepository.ListAsync();
        }

        public async Task UpdateAsync(State state) => await _statrepository.UpdateAsync(state);

    }
}