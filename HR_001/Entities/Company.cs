using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Company Id")]
        public int Id { get; set; }

        [ForeignKey("CompanyType")]
        [Required]
        public int CompanyTypeId { get; set; }

        [Display(Name = "CompanyType")]
        [NotMapped]
        public string CompanyTypeName { get; set; }

        public virtual CompanyType CompanyType { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyNameArb { get; set; }

        [Column(TypeName = "ntext")]
        public string Descriptions { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
