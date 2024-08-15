using Clinica.Application.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Application.Implement
{
	public class DocumentTypeApp : IDocumentTypeApp
	{
		private readonly IDocumentTypeDom _IDocumentTypeDom;
        public DocumentTypeApp(IDocumentTypeDom IDocumentTypeDom)
        {
            this._IDocumentTypeDom = IDocumentTypeDom;
        }

        public async Task<List<DocumentTypeDTO>> Collection()
        {
            return await _IDocumentTypeDom.Collection();
        }
        
    }
}
