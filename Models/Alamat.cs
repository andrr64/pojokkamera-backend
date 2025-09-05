using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Alamat")]
    public class Alamat
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdPengguna { get; set; }

        [StringLength(50)]
        public string LabelAlamat { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NamaPenerima { get; set; } = string.Empty;

        [Required]
        public string DetailJalan { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Kota { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string KodePos { get; set; } = string.Empty;

        public bool AlamatUtama { get; set; }

        // Navigation Property (Many-to-One)
        [ForeignKey("IdPengguna")]
        public UserModel? Pengguna { get; set; }
    }
}
