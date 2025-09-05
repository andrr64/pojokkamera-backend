using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string HashKataSandi { get; set; } = string.Empty;

        [StringLength(100)]
        public string NamaLengkap { get; set; } = string.Empty;

        [StringLength(20)]
        public string NomorTelepon { get; set; } = string.Empty;

        public DateTime DibuatPada { get; set; } = DateTime.UtcNow;

        // Navigation Properties (One-to-Many)
        public ICollection<Alamat> Alamat { get; set; } = [];
        public ICollection<Ulasan> Ulasan { get; set; } = [];
        public ICollection<Pesanan> Pesanan { get; set; } = [];
    }
}
