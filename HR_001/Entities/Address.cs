using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Address Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string District { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string HouseNumber { get; set; }

        [Required]
        [Display(Name = "Residence Card Number")]
        [MaxLength(200)]
        public string RCN { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

       // [ForeignKey("Region")]
        [Required]
        public int? RegionId { get; set; }

       // [Display(Name = "Region")]
      //  [NotMapped]
      //  public string RegionName { get; set; }

       // public virtual Region Region { get; set; }


        [ForeignKey("Employee")]
        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        //[Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

       // [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }


    }
}
