using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Requests
{
    public class EmpAddressRequest
    {
        [Required]
        [MaxLength(200)]
        public string District { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string HouseNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string RCN { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int? RegionId { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public int EmployeeId { get; set; }

       // [Required]
        public DateTime? CreatedDate { get; set; }

        //[Required]
        public DateTime? UpdatedDate { get; set; }
    }
}
