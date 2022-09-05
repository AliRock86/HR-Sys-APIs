using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests
{
    public class RefreshTokenRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string RefreshToken { get; set; }

    }
}