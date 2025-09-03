using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Data;
using pojokkamera_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pojokkamera_backend.Controllers
{
    [ApiController]
    [Route("api/v1/kamera")] // Ini mendefinisikan URL endpoint Anda
    public class KameraController : ControllerBase
    {
        private readonly PojokKameraDbContext _context;

        // DbContext akan di-inject secara otomatis oleh service container
        public KameraController(PojokKameraDbContext context)
        {
            _context = context;
        }

        // Metode ini akan menangani HTTP GET request ke /api/v1/kamera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kamera>>> GetSemuaKamera()
        {
            // Mengambil semua data dari tabel Kamera
            var daftarKamera = await _context.Kamera
                                        .Include(k => k.Merek) // Menyertakan data Merek terkait
                                        .Include(k => k.SpekKamera) // Menyertakan data SpekKamera terkait
                                        .ToListAsync();
            return Ok(daftarKamera);
        }

        // Anda bisa menambahkan metode lain di sini (GET by ID, POST, PUT, DELETE)
    }
}
