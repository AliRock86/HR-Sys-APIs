using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Requests
{
    public class AttachmentRequest
    {
        [Required]
        [MaxLength(512)]
        public string AttachmentUrl { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int AttachmentTypeId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
