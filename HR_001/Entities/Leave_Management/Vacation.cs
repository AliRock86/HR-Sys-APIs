using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities.Leave_Management
{
    public class Vacation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [ForeignKey("VacationType")]
        [Required]
        public int VacationTypeId { get; set; }

        public virtual VacationType VacationType { get; set; }

        [ForeignKey("Employee")]
        [Required] 
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int? EmployeeReplaceId { get; set; }

       // [ForeignKey("Status")]
        [Required]
        public int StatusId { get; set; }

       // public virtual Status Status { get; set; }

        [MaxLength(5000)]
        public string? Description { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
