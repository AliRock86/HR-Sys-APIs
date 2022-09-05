using System.ComponentModel.DataAnnotations;

namespace HR_001.Requests
{
    public class SalaryRequest
    {

        [Required]
        public int Value { get; set; }

        [Required]
        public bool IsUSD { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
