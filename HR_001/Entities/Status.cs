using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusNameArb { get; set; }

        [ForeignKey("StatusType")]
        [Required]
        public int StatusTypeId { get; set; }

        [Display(Name = "StatusType")]
        [NotMapped]
        public string StatusTypeName { get; set; }

        public virtual StatusType StatusType { get; set; }

        public virtual Employee Employee { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
