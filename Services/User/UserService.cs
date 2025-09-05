using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Data;
using pojokkamera_backend.Dtos.Common;
using pojokkamera_backend.Dtos.User;

namespace pojokkamera_backend.Services.User
{
    public class UserService
    {
        private readonly PojokKameraDbContext _context;

        public UserService(PojokKameraDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<UserResponseDto>> GetMe(long userId)
        {
            var user = await _context.User
                .Where(u => u.Id == userId)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email
                    // Tambahkan properti lain yang mau dikembalikan
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return new ApiResponse<UserResponseDto>
                {
                    Success = false,
                    Detail = "User not found",
                    Data = null
                };
            }

            return new ApiResponse<UserResponseDto>
            {
                Success = true,
                Detail = "User data fetched successfully",
                Data = user
            };
        }
    }
}
