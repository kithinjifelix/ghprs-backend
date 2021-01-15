using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await Task.Run(() => _userManager.Users);
            return Ok(users);
        }

        [HttpGet("USERID")]
        public async Task<User> GetUser()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);
            return await _userManager.FindByNameAsync(userName);
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

    }
}
