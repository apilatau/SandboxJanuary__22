using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly ILogger<ReserveController> logger;

        public RoleController(IRoleService roleService, ILogger<ReserveController> logger)
        {
            this.roleService = roleService;
            this.logger = logger;
        }

        [HttpPost("addrole")]
        public async Task<Role> AddRole(Role role)
        {
            return await roleService.AddAsync(role);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(Role role) => await roleService.DeleteAsync(role);

        [HttpGet("role/{id}")]
        public async Task<Role> GetByIdAsync(int id)
        {
            return await roleService.GetByIdAsync(id);
        }

        [HttpGet("role")]
        public async Task<List<Role>> ListAsync()
        {
            return await roleService.ListAsync();
        }

        [HttpPut("update")]
        public async Task UpdateAsync(Role role) => await roleService.UpdateAsync(role);


    }
}
