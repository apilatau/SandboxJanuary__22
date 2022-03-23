using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<Userr> AddUser(Userr user)
        {
            return await _userService.AddAsync(user);
        }

        [HttpGet("getallusers")]

        public async Task<List<Userr>> GetUsers()
        {
            return await _userService.ListAsync();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.AuthenticateAsync(model);

            if (response == null)
                    return BadRequest(new { message = "TelegramId is incorrect" });

            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task DeleteAsync(Userr user) => await _userService.DeleteAsync(user);
    }
}


