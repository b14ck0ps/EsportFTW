using EsportFTW_DAL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EsportFTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<LoginDto> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_authService.IsAuthenticated(loginDto)) return Ok(loginDto.Email);
            ModelState.AddModelError("Login", "Wrong login credentials");
            return Unauthorized(ModelState);
        }
    }
}
