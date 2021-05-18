using System;
using System.Security.Claims;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LinksController> _logger;

        public UsersController(ILogger<LinksController> logger, UserManager<User> userManager, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsersAsync()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("USERID")]
        public User GetUser()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);
            return _userRepository.GetByUserName(userName);
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userRepository.GetById(id);
        }

        [HttpPut("{id}")]
        public User Update(string id, [FromBody] Person person)
        {
            var user = _userRepository.GetById(id);
            user.Person = person;
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
