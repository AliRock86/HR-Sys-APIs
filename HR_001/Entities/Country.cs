using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Country Id")]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryNameArb { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
