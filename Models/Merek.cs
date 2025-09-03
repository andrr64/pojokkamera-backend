using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Merek")]
    public class Merek
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaMerek { get; set; } = string.Empty;

        // Navigation Properties (One-to-Many)
        public ICollection<Kamera> Kamera { get; set; } = new List<Kamera>();
        public ICollection<Lensa> Lensa { get; set; } = new List<Lensa>();
    }
}
