using Microsoft.AspNetCore.Mvc;
using pojokkamera_backend.Dtos.User;
using pojokkamera_backend.Services;
using pojokkamera_backend.Security;

namespace pojokkamera_backend.Controllers.User
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        // Dependency Injection untuk DbContext
        public AuthController(AuthService service)
        {
            _service = service;
        }

        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto registerDto)
        {
            var result = await _service.Register(registerDto);
            if (!result.Success)
                return Conflict(result);
            return Ok(result);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto loginDto)
        {
            var result = await _service.Login(loginDto);

            if (!result.Success || result.Data == null)
                return Conflict(result);

            var token = JWTToken.GenerateUserJWTAccessToken(
                result.Data.Id.ToString(),
                result.Data.Email,
                result.Data.Username
            );

            // Kirim token di response body, bukan cookie
            return Ok(new
            {
                Success = true,
                Detail = "Login berhasil",
                Data = result.Data,
                AccessToken = token
            });
        }

    }
}