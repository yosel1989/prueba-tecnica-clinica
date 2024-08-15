using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Entity.Models
{
    [Table("Ubigeo")]
    public class Ubigeo
    {
        [Key]
        public string UbigeoCode { get; set; }
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string UbigeoDescription { get; set; }
        
    }
}
