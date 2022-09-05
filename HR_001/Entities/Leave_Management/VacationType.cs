using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Entities.Leave_Management
{
    public class VacationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string VacationTypeName { get; set; }

        [Required]
        public string VacationTypeNameArb { get; set; }

        public virtual  ICollection<Vacation> Vacations { get; set; }


    }
}
