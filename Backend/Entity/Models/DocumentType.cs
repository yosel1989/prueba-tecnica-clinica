using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Entity.Models
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }
        
    }
}
