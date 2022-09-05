using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class EmployeePosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EmployeePosition Id")]
        public int Id { get; set; }

        [ForeignKey("PositionType")]
        [Required]
        public int PositionTypeId { get; set; }

        [Display(Name = "Position Type Name")]
        [NotMapped]
        public string PositionTypeName { get; set; }

        public virtual PositionType PositionType { get; set; }


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
