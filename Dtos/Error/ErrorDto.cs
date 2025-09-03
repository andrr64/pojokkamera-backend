using System.ComponentModel.DataAnnotations;

namespace pojokkamera_backend.Dtos.Error
{
    public class ErrorDto
    {
        [Required]
        public string Detail { get; set; } = string.Empty;
    }
}
