using Microsoft.EntityFrameworkCore;
using pojokkamera_backend.Models;

namespace pojokkamera_backend.Data
{
    public class PojokKameraDbContext : DbContext
    {
        public PojokKameraDbContext(DbContextOptions<PojokKameraDbContext> options) : base(options)
        {
        }

        // Daftarkan semua model Anda sebagai DbSet di sini
        public DbSet<UserModel> User { get; set; }
        public DbSet<Alamat> Alamat { get; set; }
        public DbSet<Merek> Merek { get; set; }
        public DbSet<KategoriProduk> KategoriProduk { get; set; }
        public DbSet<TipeMount> TipeMount { get; set; }
        public DbSet<Kamera> Kamera { get; set; }
        public DbSet<SpekKamera> SpekKamera { get; set; }
        public DbSet<Lensa> Lensa { get; set; }
        public DbSet<Ulasan> Ulasan { get; set; }
        public DbSet<Pesanan> Pesanan { get; set; }
        public DbSet<DetailPesanan> DetailPesanan { get; set; }
    }
}
