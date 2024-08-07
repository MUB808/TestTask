using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTO;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services;
using System.Threading.Tasks;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {                    
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    Phone = model.Phone
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok(new { Result = "User created successfully" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenmodel = _jwtService.GenerateSecurityToken(user);
                    return Ok(tokenmodel);
                }

                return Unauthorized("Invalid username or password");
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("assign-admin-role")]
        public async Task<IActionResult> AssignAdminRole([FromBody] AssignRoleDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, "Administrator");
            if (result.Succeeded)
            {
                return Ok(new { Result = "User assigned to Administrator role successfully" });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
