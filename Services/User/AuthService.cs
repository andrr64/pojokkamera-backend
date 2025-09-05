using pojokkamera_backend.Data;
using pojokkamera_backend.Dtos.Common;
using pojokkamera_backend.Dtos.User;
using pojokkamera_backend.Models;
using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Security;

namespace pojokkamera_backend.Services
{
    public class AuthService
    {
        private readonly PojokKameraDbContext _context;

        public AuthService(PojokKameraDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<UserResponseDto>> Register(UserRegisterDto dto)
        {
            // cek username/email sudah ada
            if (await _context.User.AnyAsync(u => u.Username == dto.Username || u.Email == dto.Email))
            {
                return ApiResponse<UserResponseDto>.Fail("Nama pengguna atau email sudah terdaftar.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                HashKataSandi = passwordHash,
                NamaLengkap = dto.NamaLengkap,
                NomorTelepon = dto.NomorTelepon ?? "",
                DibuatPada = DateTime.UtcNow
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var response = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                NamaLengkap = user.NamaLengkap,
                DibuatPada = user.DibuatPada
            };

            return ApiResponse<UserResponseDto>.Ok(response, "Registrasi berhasil");
        }

        public async Task<ApiResponse<UserResponseDto>> Login(UserLoginDto dto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.HashKataSandi))
            {
                return ApiResponse<UserResponseDto>.Fail("Email atau password salah.");
            }


            var response = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                NamaLengkap = user.NamaLengkap,
                DibuatPada = user.DibuatPada
            };

            return ApiResponse<UserResponseDto>.Ok(response, "Login berhasil");
        }
    }
}
