using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Model;
using GHPRS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GHPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMetabaseService _metabaseService;

        public AuthenticationController(
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, 
            IOrganizationRepository organizationRepository, 
            IMetabaseService metabaseService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _organizationRepository = organizationRepository;
            _metabaseService = metabaseService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ??
                       await _userManager.FindByNameAsync(model.Email);
            if (user != null && user.IsEnabled && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles) authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    _configuration["JWT:ValidIssuer"],
                    _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("REGISTER")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Email);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response {Status = "Error", Message = "User already exists!"});

                var person = new Person
                {
                    Name = model.Name,
                    GenderId = 0,
                    MaritalStatusId = 0,
                    DateOfBirth = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var organization = _organizationRepository.GetById(model.OrganizationId);
                var user = new User
                {
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    Person = person,
                    Organization = organization
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    var errors = "";
                    foreach (var e in result.Errors)
                    {
                        var error = "";
                        error = e.Description;
                        errors += " " + error;
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response
                            {Status = "Error", Message = $"User creation failed! Please Check your details. {errors} !"});
                }
                var names = model.Name.Split(' ');
                string firstName = names[0];
                string lastName = names[1];
                int[] groupIds = {1, 2};

                var metabaseUser = new MetabaseUser()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = model.Email,
                    Password = model.Password,
                    GroupIds = groupIds
                };

                if (!await _roleManager.RoleExistsAsync(UserRoles.Administrator))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Administrator));
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                if (model.RoleId == 0)
                {
                    if (await _roleManager.RoleExistsAsync(UserRoles.Administrator))
                        await _userManager.AddToRoleAsync(user, UserRoles.Administrator);
                    // await _metabaseService.CreateUser(metabaseUser).ConfigureAwait(false);
                }
                else if (model.RoleId == 1)
                {
                    if (await _roleManager.RoleExistsAsync(UserRoles.User))
                        await _userManager.AddToRoleAsync(user, UserRoles.User);
                }

                return Ok(new Response {Status = "Success", Message = "User created successfully!"});
            }
            catch (Exception e)
            {
                return BadRequest(new Response {Status = "Error", Message = $"An error occured while registering a user {e.Message}"});
            }
        }

        [HttpPost]
        [Route("RESETPASSWORD/{id}")]
        public async Task<IActionResult> ResetPassword(string id, [FromBody]ResetPassword resetPassword)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, resetPassword.Password);
                return Ok(new Response {Status = "Success", Message = "Successfully reset user password!"});
            }
            catch (Exception e)
            {
                return BadRequest(new Response {Status = "Error", Message = $"An error occured while resetting user password {e.Message}"});
            }
        }
    }
}