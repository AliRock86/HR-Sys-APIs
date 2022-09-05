using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Column(TypeName ="bigint")]
        public int Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }
        public bool Active { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }

        public DateTime Ts { get; set; }

        public virtual Status Status { get; set; }
        public int RoleId { get; set; }
        public int? EmployeeId { get; set; }
        public int StatusId { get; set; }
        public virtual Role Role { get; set; }

        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
