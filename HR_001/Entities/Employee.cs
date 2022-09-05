using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee Id")]
        public int Id { get; set; }

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
        public int NoOfChildreen{ get; set; }

        [Required]
        public int NationalId { get; set; }

        [Required]
        public int GovernmentId { get; set; }

        [Required]
        public int PassportId { get; set; }

        [ForeignKey("Province")]
        [Required]
        public int  ProvinceId{ get; set; }
        [NotMapped]
        public string PlaceOfBirth { get; set; }
        public virtual Province Province { get; set; }

        [ForeignKey("Status")]
        [Required]
        public int StatusId { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        public virtual Status Status { get; set; }

        [ForeignKey("Company")]
        [Required]
        public int CompanyId { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        public virtual Company Company { get; set; }  

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<JobTitle> JobTitles { get; set; }
        public virtual ICollection<EmployeePosition> EmployeePositions { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
