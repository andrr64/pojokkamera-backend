using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pojokkamera_backend.Models
{
    [Table("Spek_Kamera")]
    public class SpekKamera
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdKamera { get; set; }

        public int TahunRilis { get; set; }
        
        [StringLength(20)]
        public string Resolusi { get; set; } = string.Empty;

        [StringLength(50)]
        public string TipeSensor { get; set; } = string.Empty;

        [StringLength(50)]
        public string Prosesor { get; set; } = string.Empty;
        
        public int JumlahTitikFokus { get; set; }
        
        public bool PunyaAutofocusSubjek { get; set; }

        // Navigation Property (One-to-One)
        [ForeignKey("IdKamera")]
        public Kamera? Kamera { get; set; }
    }
}
