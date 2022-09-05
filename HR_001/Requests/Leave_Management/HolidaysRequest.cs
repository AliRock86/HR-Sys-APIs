using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests.Leave_Management
{
    public class HolidaysRequest
    {
        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public int CompanyId { get; set; } 

        [Required]
        public int UserId { get; set; }

        [MaxLength(5000)]
        public string? Description { get; set; }
    }
}
