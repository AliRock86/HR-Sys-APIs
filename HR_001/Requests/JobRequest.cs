using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests
{
    public class JobRequest
    {

        [Required]
        public int JobTypeId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
