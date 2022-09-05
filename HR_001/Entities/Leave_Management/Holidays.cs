using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities.Leave_Management
{
    public class Holidays
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [ForeignKey("Company")]
        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        
        [MaxLength(5000)] 
        public string? Description { get; set; }

    }
}
