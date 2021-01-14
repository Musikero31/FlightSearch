using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.Data.EF.Entities
{
    [Table("Airlines")]
    public partial class Airlines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(100)]
        public string AirlineName { get; set; }

        [StringLength(5)]
        public string CarrierCode { get; set; }

        public string LogoUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
