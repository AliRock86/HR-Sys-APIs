using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Education Id")]
        public int Id { get; set; }

        [ForeignKey("EducationType")]
        [Required]
        public int EducationTypeId { get; set; }

        [Display(Name = "Education Type Name")]
        [NotMapped]
        public string EducationTypeName { get; set; }

        public virtual EducationType EducationType { get; set; }


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
