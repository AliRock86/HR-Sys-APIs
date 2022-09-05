using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class JobType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "JobTitle Id")]
        public int Id { get; set; }
        public string JobTypeName { get; set; }
        public string JobTypeArb { get; set; }
        public virtual ICollection<JobTitle> JobTitle { get; set; }
    }
}
