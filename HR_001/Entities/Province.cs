using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Province Id")]
        public int Id { get; set; }

        public string ProvinceName { get; set; }
        public string ProvinceNameArb { get; set; }

        [ForeignKey("Country")]
        [Required]
        public int CountryId { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
