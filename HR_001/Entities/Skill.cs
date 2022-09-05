using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Skill Id")]
        public int Id { get; set; }

        public string SkillName { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public int EmployeeId { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
        public virtual Employee Employee { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
