using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Data;
using pojokkamera_backend.Dtos.Pengguna;
using pojokkamera_backend.Models;
// PENTING: Untuk hashing password, instal paket ini melalui terminal:
// dotnet add package BCrypt.Net-Next

namespace pojokkamera_backend.Controllers
{
    [ApiController]
    [Route("api/v1/pengguna")]
    public class PenggunaController : ControllerBase
    {
        private readonly PojokKameraDbContext _context;

        // Dependency Injection untuk DbContext
        public PenggunaController(PojokKameraDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint untuk mendaftarkan pengguna baru.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterPengguna([FromBody] RegisterPenggunaDto registerDto)
        {
            // Validasi input dilakukan secara otomatis oleh [ApiController] berdasarkan DTO.
            // Jika ada yang tidak valid, framework akan otomatis mengembalikan response 400 Bad Request.

            // Cek apakah email atau nama pengguna sudah terdaftar di database
            if (await _context.Pengguna.AnyAsync(p => p.NamaPengguna == registerDto.NamaPengguna || p.Email == registerDto.Email))
            {
                return Conflict("Nama pengguna atau email sudah terdaftar.");
            }

            // --- BAGIAN KRUSIAL: HASHING PASSWORD ---
            // Jangan pernah menyimpan password sebagai plain text. Selalu hash password sebelum disimpan.
            // Gunakan library seperti BCrypt.Net untuk ini.
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            // Buat entitas Pengguna baru dari data DTO
            var penggunaBaru = new Pengguna
            {
                NamaPengguna = registerDto.NamaPengguna,
                Email = registerDto.Email,
                HashKataSandi = passwordHash, // Simpan hash, bukan password asli
                NamaLengkap = registerDto.NamaLengkap,
                NomorTelepon = registerDto.NomorTelepon,
                DibuatPada = DateTime.UtcNow
            };

            // Tambahkan pengguna baru ke DbContext dan simpan perubahan ke database
            _context.Pengguna.Add(penggunaBaru);
            await _context.SaveChangesAsync();

            // Kembalikan response 201 Created yang menandakan sukses.
            // Sebaiknya buat DTO lain untuk respons agar tidak mengembalikan data sensitif.
            return CreatedAtAction(nameof(RegisterPengguna), new { id = penggunaBaru.Id }, "Registrasi pengguna berhasil.");
        }
    }
}
