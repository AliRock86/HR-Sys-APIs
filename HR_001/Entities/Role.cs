using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameArb { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
