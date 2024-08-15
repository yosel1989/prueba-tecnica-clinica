using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Entity.Models
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string ProvinceDescription { get; set; }
        
    }
}
