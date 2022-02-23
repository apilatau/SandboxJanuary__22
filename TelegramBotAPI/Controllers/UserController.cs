using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<User> AddAsync(User user)
        {
            return await _userService.AddAsync(user);
        }

        [HttpGet]
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<User>> ListAsync()
        {
            return await _userService.ListAsync();
        }

        [HttpDelete]
        public async Task<User> DeleteAsync(User user)
        {
           return user;
        }
    }
}


