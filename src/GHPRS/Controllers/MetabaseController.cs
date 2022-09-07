using System;
using System.Threading.Tasks;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MetabaseController : ControllerBase
    {
        private readonly IMetabaseService _metabaseService;

        public MetabaseController(IMetabaseService metabaseService)
        {
            _metabaseService = metabaseService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                var result = await _metabaseService.GetSessionToken();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return await _metabaseService.GetCurrentUser();
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> GetCurrentUser([FromBody] MetabaseUser user)
        {
            return await _metabaseService.CreateUser(user);
        }
    }
}