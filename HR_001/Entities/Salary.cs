using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Salary Id")]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public bool IsUSD { get; set; }

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
