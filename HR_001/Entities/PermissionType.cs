using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class PermissionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PermissionType Id")]
        public int Id { get; set; }
        public string PermissionTypeName { get; set; }
        public string PermissionTypeNameArb { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
