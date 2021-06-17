using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GHPRS.Core.Models;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LinksController> _logger;

        public UsersController(ILogger<LinksController> logger, UserManager<User> userManager, IUserRepository userRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsersAsync()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("USERID")]
        public async Task<User> GetUser()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);
            var user = _userRepository.GetByUserName(userName);
            var roles = await _userManager.GetRolesAsync((User)user);
            user.RoleId = roles.FirstOrDefault() switch
            {
                "Administrator" => 0,
                "User" => 1,
                _ => user.RoleId
            };
            return user;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            dynamic user = _userRepository.GetById(id);
            var roles = await _userManager.GetRolesAsync((User) user);
            user.RoleId = roles.FirstOrDefault() switch
            {
                "Administrator" => 0,
                "User" => 1,
                _ => user.RoleId
            };
            return user;
        }

        [HttpPut("{id}")]
        public async Task<User> Update(string id, [FromBody] EditUser model)
        {
            var user = _userRepository.GetById(id);
            user.Person.Name = model.Name;
            user.OrganizationId = model.OrganizationId;
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            if (model.RoleId == 0)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Administrator);
            }
            else if (model.RoleId == 1)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            _userRepository.Update(user);
            return user;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
    }
}
