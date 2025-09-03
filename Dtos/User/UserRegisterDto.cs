using System.ComponentModel.DataAnnotations;

namespace pojokkamera_backend.Dtos.User
{
    /// <summary>
    /// Data Transfer Object (DTO) untuk menangani permintaan registrasi pengguna baru.
    /// Ini mendefinisikan "bentuk" data yang harus dikirim oleh klien.
    /// </summary>
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Nama pengguna wajib diisi.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nama pengguna harus antara 3 dan 50 karakter.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kata sandi wajib diisi.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Kata sandi minimal 6 karakter.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama lengkap wajib diisi.")]
        public string NamaLengkap { get; set; } = string.Empty;
        
        public string? NomorTelepon { get; set; }
    }
}
