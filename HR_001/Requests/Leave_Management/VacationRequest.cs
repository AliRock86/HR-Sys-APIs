using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests.Leave_Management
{
    public class VacationRequest
    {
        [Required]
        public DateTime FromDate { get; set; }

        [Required] 
        public DateTime ToDate { get; set; }

        [Required]
        public int VacationTypeId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public int? EmployeeReplaceId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int StatusId { get; set; }


        [MaxLength(5000)]
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
