using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Permission Id")]
        public int Id { get; set; }

        [ForeignKey("PermissionType")]
        [Required]
        public int PermissionTypeId { get; set; }

        [Display(Name = "PermissionType")]
        [NotMapped]
        public string PermissionTypeName { get; set; }

        public virtual PermissionType PermissionType { get; set; }


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
