using Clinica.Entity.DTO;

namespace Clinica.Domain.Interface
{
	public interface IDocumentTypeDom
	{
        Task<List<DocumentTypeDTO>> Collection();
    }
}
