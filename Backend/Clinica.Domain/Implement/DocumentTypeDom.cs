
using Clinica.Data.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Domain.Implement
{
    public class DocumentTypeDom: IDocumentTypeDom
	{
		private readonly IDocumentTypeDat _IDocumentTypeDat;
		public DocumentTypeDom(IDocumentTypeDat IDocumentTypeDat)
		{
			this._IDocumentTypeDat = IDocumentTypeDat;
		}
		public async Task<List<DocumentTypeDTO>> Collection()
		{
			return await _IDocumentTypeDat.Collection();
		}


    }
}
