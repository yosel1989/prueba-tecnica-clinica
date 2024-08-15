using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Entity.Models
{
    [Table("LibeyUser")]
    public class User
    {
        [Key]
        public string DocumentNumber { get; set; }

        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string FathersLastName { get; set; }
        public string MothersLastName { get; set; }
        public string Address { get; set; }
        public string UbigeoCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

    }
}
