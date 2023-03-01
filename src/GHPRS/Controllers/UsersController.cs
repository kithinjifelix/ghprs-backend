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
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(ILogger<LinksController> logger, 
            UserManager<User> userManager, 
            IUserRepository userRepository,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _userRepository = userRepository;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = _userManager.Users
                .Include(x => x.Person)
                .Include(z => z.Organization)
                .Where(x => x.IsEnabled)
                .Select(u => new { User = u, Roles = new List<string>() })
                .ToList();
            //Fetch all the Roles
            var roleNames = _roleManager.Roles.Select(r => r.Name).ToList();

            foreach (var roleName in roleNames)
            {
                //For each role, fetch the users
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

                //Populate the roles for each user in memory
                var toUpdate = users.Where(u => usersInRole.Any(ur => ur.Id == u.User.Id));
                foreach (var user in toUpdate)
                {
                    user.Roles.Add(roleName);
                }
            }
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
            try
            {
                var user = await _userManager.Users
                    .Include(x => x.Person)
                    .Include(z => z.Organization)
                    .FirstOrDefaultAsync(x => x.Id == id);
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
                user.Person.Name = model.Name;
                user.OrganizationId = model.OrganizationId;
                await _userManager.UpdateAsync(user);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("DisableUser/{id}")]
        public async Task<IActionResult> DisableUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                user.IsEnabled = false;
                await _userManager.UpdateAsync(user);
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
