using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Entity.Models
{
    [Table("Region")]
    public class Region
    {
        [Key]
        public string RegionCode { get; set; }
        public string RegionDescription { get; set; }
        
    }
}
