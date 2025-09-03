using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Pesanan")]
    public class Pesanan
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdPengguna { get; set; }

        [Required]
        public long IdAlamatPengiriman { get; set; }

        public DateTime TanggalPesanan { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal JumlahTotal { get; set; }
        
        [StringLength(50)]
        public string Status { get; set; } = string.Empty;

        // Navigation Properties (Many-to-One)
        [ForeignKey("IdPengguna")]
        public Pengguna? Pengguna { get; set; }

        [ForeignKey("IdAlamatPengiriman")]
        public Alamat? AlamatPengiriman { get; set; }

        // Navigation Property (One-to-Many)
        public ICollection<DetailPesanan> DetailPesanan { get; set; } = new List<DetailPesanan>();
    }
}
