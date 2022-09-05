using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Region Id")]
        public int Id { get; set; }
        public string RegionName { get; set; }
        public string RegionArb { get; set; }

        [ForeignKey("Province")]
        [Required]
        public int ProvinceId { get; set; }
        [NotMapped]
        public string ProvinceName { get; set; }
        public virtual Province Province { get; set; }
       // public virtual ICollection<Address> Addresses { get; set; }
    }
}
