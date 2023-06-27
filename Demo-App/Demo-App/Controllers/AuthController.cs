
using Demo_App.Model.Dto;
using Demo_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRep tokenrep;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRep tokenrep)
        {
            this.userManager = userManager;
            this.tokenrep = tokenrep;
        }
        //Post:/api/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {

                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("Registration Successful.Please login");
                    }
                }
            }
            return BadRequest("Something went wrong");

        }
        //Post:/api/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var User = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (User != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(User, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    //get roles
                    var roles = await userManager.GetRolesAsync(User);
                    //create token
                    if (roles != null)
                    {
                        var jwtToken = tokenrep.CreateJWToken(User, roles.ToList());
                        return Ok(jwtToken);
                    }

                }
            }
            return BadRequest("Username or Password incorrect");
        }


    }
}