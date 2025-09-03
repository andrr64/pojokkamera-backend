using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Ulasan")]
    public class Ulasan
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdPengguna { get; set; }

        // An review can be for a camera OR a lens
        public long? IdKamera { get; set; }
        public long? IdLensa { get; set; }

        [Range(1, 5)]
        public int Peringkat { get; set; }

        public string Komentar { get; set; } = string.Empty;
        
        public DateTime DibuatPada { get; set; } = DateTime.UtcNow;

        // Navigation Properties (Many-to-One)
        [ForeignKey("IdPengguna")]
        public User? Pengguna { get; set; }

        [ForeignKey("IdKamera")]
        public Kamera? Kamera { get; set; }
        
        [ForeignKey("IdLensa")]
        public Lensa? Lensa { get; set; }
    }
}
