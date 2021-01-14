using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.Data.EF.Entities
{
    [Table("Airports")]
    public class Airports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(5)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
