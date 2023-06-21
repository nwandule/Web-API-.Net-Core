using Demo_App.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Post:/api/register
        [HttpPost]
        [Route("Regiter ")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        { 
            this.userManager=UserManager
        }


    }
}
