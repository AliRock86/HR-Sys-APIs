using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class BranchType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "BranchType Id")]
        public int Id { get; set; }
        public string BranchTypeName { get; set; }
        public string BranchTypeNameArb { get; set; }  
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
