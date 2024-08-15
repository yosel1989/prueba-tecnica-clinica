
using Clinica.Entity.DTO;

namespace Clinica.Application.Interface
{
    public interface IDocumentTypeApp
	{
		Task<List<DocumentTypeDTO>> Collection();
    }
}
