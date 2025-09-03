using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Data;
using pojokkamera_backend.Dtos.User;
using pojokkamera_backend.Models;
// PENTING: Untuk hashing password, instal paket ini melalui terminal:
// dotnet add package BCrypt.Net-Next

namespace pojokkamera_backend.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly PojokKameraDbContext _context;

        // Dependency Injection untuk DbContext
        public UserController(PojokKameraDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint untuk mendaftarkan pengguna baru.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto registerDto)
        {
            // Validasi input dilakukan secara otomatis oleh [ApiController] berdasarkan DTO.

            // Cek apakah email atau nama pengguna sudah terdaftar di database
            if (await _context.User.AnyAsync(p => p.Username == registerDto.Username || p.Email == registerDto.Email))
            {
                return Conflict("Nama pengguna atau email sudah terdaftar.");
            }

            // --- BAGIAN KRUSIAL: HASHING PASSWORD ---
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            // Buat entitas Pengguna baru dari data DTO
            var penggunaBaru = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                HashKataSandi = passwordHash, // Simpan hash, bukan password asli
                NamaLengkap = registerDto.NamaLengkap,
                NomorTelepon = registerDto.NomorTelepon,
                DibuatPada = DateTime.UtcNow
            };

            // Tambahkan pengguna baru ke DbContext dan simpan perubahan ke database
            _context.User.Add(penggunaBaru);
            await _context.SaveChangesAsync();
            var responseDto = new UserResponseDto
            {
                Id = penggunaBaru.Id,
                Username = penggunaBaru.Username,
                Email = penggunaBaru.Email,
                NamaLengkap = penggunaBaru.NamaLengkap,
                DibuatPada = penggunaBaru.DibuatPada
            };

            // Kembalikan response 201 Created yang menandakan sukses.
            // Sebaiknya buat DTO lain untuk respons agar tidak mengembalikan data sensitif.
            return CreatedAtAction(
                nameof(UserRegister),
                new { id = penggunaBaru.Id },
                responseDto
            );
        }
    }
}
