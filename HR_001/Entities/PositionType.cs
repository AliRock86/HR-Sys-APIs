using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class PositionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PositionType Id")]
        public int Id { get; set; }
        public string PositionTypeName { get; set; }
        public string PositionTypeArb { get; set; }

        public virtual ICollection<JobTitle> JobTitle { get; set; }


    }
}
