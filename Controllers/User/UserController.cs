using Microsoft.AspNetCore.Mvc;
using pojokkamera_backend.Services.User;
using System.IdentityModel.Tokens.Jwt;
using System.Linq; // buat FirstOrDefault()

namespace pojokkamera_backend.Controllers.User
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUserData()
        {
            var authHeader = Request.Headers.Authorization.FirstOrDefault();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized("Token not provided");

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(token))
                return Unauthorized("Invalid token");

            var jwtToken = jwtHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Token missing userId");

            // Convert ke long
            if (!long.TryParse(userIdClaim, out var userId))
                return Unauthorized("Invalid userId in token");

            var result = await _service.GetMe(userId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

    }
}