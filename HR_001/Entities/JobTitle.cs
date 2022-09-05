using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class JobTitle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "JobTitle Id")]
        public int Id { get; set; }

        [ForeignKey("JobType")]
        [Required]
        public int JobTypeId { get; set; }

        [Display(Name = "Job Type Name")]
        [NotMapped]
        public string JobTypeName { get; set; }

        public virtual JobType JobType { get; set; }


        [ForeignKey("Employee")]
        [Required]
        public int EmployeeId { get; set; }


        public virtual Employee Employee { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
