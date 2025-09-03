using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Detail_Pesanan")]
    public class DetailPesanan
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdPesanan { get; set; }

        // Sebuah item pesanan bisa berupa kamera ATAU lensa
        public long? IdKamera { get; set; }
        public long? IdLensa { get; set; }

        public int Kuantitas { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HargaSaatPembelian { get; set; }

        // Navigation Properties (Many-to-One)
        [ForeignKey("IdPesanan")]
        public Pesanan? Pesanan { get; set; }

        [ForeignKey("IdKamera")]
        public Kamera? Kamera { get; set; }

        [ForeignKey("IdLensa")]
        public Lensa? Lensa { get; set; }
    }
}

