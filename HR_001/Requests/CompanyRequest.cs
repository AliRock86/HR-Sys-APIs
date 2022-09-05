using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_001.Requests
{
    public class CompanyRequest
    {
        [Required]
        public int CompanyTypeId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyNameArb { get; set; }

        public string Descriptions { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
    }
}
