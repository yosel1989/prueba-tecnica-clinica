

using Clinica.Entity.DTO;

namespace Clinica.Data.Interface
{
	public interface IDocumentTypeDat
	{
		Task<List<DocumentTypeDTO>> Collection();
    }
}
