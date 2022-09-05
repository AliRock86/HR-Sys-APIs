using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class AttachmentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "AttachmentType Id")]
        public int Id { get; set; }
        public string AttachmentTypeName { get; set; }
        public string AttachmentTypeArb { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
