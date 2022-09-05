using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Requests
{
    public class AddEmployeeRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ThirdName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LasttName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FamilytName { get; set; }

        [Required]
        [MaxLength(200)]
        public string MotherName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public string DOB { get; set; }

        [Required]
        public bool Gendar { get; set; }

        [Required]
        public bool MartialState { get; set; }

        [Display(Name = "Number of Childreen")]
        [Required]
        public int NoOfChildreen { get; set; }

        [Required]
        public int NationalId { get; set; }

        [Required]
        public int GovernmentId { get; set; }

        [Required]
        public int PassportId { get; set; }

        [ForeignKey("Province")]
        [Required]
        public int ProvinceId { get; set; }

        [ForeignKey("Status")]
        [Required]
        public int StatusId { get; set; }
    }
}
