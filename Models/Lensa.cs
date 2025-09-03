using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Lensa")]
    public class Lensa
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdMerek { get; set; }

        [Required]
        public long IdKategori { get; set; }

        [Required]
        public long IdMount { get; set; }

        [Required]
        [StringLength(255)]
        public string Nama { get; set; } = string.Empty;

        [StringLength(50)]
        public string Sku { get; set; } = string.Empty;

        public string Deskripsi { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Harga { get; set; }

        public int JumlahStok { get; set; }

        public int PanjangFokusMin { get; set; }
        public int PanjangFokusMaks { get; set; }

        [StringLength(10)]
        public string BukaanMaksimal { get; set; } = string.Empty;

        public string UrlGambar { get; set; } = string.Empty;

        // Navigation Properties (Many-to-One)
        [ForeignKey("IdMerek")]
        public Merek? Merek { get; set; }

        [ForeignKey("IdKategori")]
        public KategoriProduk? Kategori { get; set; }

        [ForeignKey("IdMount")]
        public TipeMount? TipeMount { get; set; }

        // Navigation Property (One-to-Many)
        public ICollection<Ulasan> Ulasan { get; set; } = new List<Ulasan>();
        public ICollection<DetailPesanan> DetailPesanan { get; set; } = new List<DetailPesanan>();
    }
}
