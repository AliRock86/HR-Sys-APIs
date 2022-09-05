using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EmployeeAttachment Id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(512)]
        public string AttachmentUrl { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("AttachmentType")]
        [Required]
        public int AttachmentTypeId { get; set; }

        [Display(Name = "AttachmentType")]
        [NotMapped]
        public string AttachmentTypeName { get; set; }

        public virtual AttachmentType AttachmentType { get; set; }


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
