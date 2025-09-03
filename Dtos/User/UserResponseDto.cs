namespace pojokkamera_backend.Dtos.User
{
    /// <summary>
    /// DTO untuk data yang dikembalikan ke klien setelah operasi berhasil.
    /// Ini memastikan bahwa data sensitif seperti hash password tidak pernah terekspos.
    /// </summary>
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NamaLengkap { get; set; } = string.Empty;
        public DateTime DibuatPada { get; set; }
    }
}
