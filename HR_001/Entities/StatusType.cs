using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class StatusType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "StatusType Id")]
        public int Id { get; set; }
        public string StatusTypeName { get; set; }
        public string StatusTypeNameArb { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}
