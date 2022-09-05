using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests
{
    public class SignupRequest
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime Ts { get; set; }

    }
}