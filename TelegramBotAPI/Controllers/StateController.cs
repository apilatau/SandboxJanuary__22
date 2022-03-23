using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }


        [HttpPost("AddState")]
        public async Task<State> AddRole(State state)
        {
            return await _stateService.AddAsync(state);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(State state) => await _stateService.DeleteAsync(state);

        [HttpGet("State/{id}")]
        public async Task<State> GetByIdAsync(int id)
        {
            return await _stateService.GetByIdAsync(id);
        }

        [HttpGet("GetAllStates")]
        public async Task<List<State>> CurrentListOfStates()
        {
            return await _stateService.CurrentListOfStates();
        }

        [HttpPut("UpdateState")]
        public async Task UpdateAsync(State state) => await _stateService.UpdateAsync(state);

    }
}
