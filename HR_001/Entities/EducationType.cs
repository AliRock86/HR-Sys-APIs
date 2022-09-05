using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class EducationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Education Type Id")]
        public int Id { get; set; }
        public string EducationTypeName { get; set; }
        public string EducationTypeArb { get; set; }

        public virtual ICollection<Education>  Education { get; set; }
    }
}
