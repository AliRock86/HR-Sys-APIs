using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class CompanyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyTypeName { get; set; }
        public string CompanyTypeNameArb { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
