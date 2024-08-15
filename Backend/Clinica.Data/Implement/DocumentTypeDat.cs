
using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data.Implement
{
	public class DocumentTypeDat : IDocumentTypeDat
	{

        private readonly ApplicationDBContext _context;

        public DocumentTypeDat(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentTypeDTO>> Collection()
        {
            try
            {
                List<DocumentTypeDTO> collection =  await _context.DocumentType.Select(u => new DocumentTypeDTO()
                {
                    Id = u.DocumentTypeId, 
                    Description = u.DocumentTypeDescription,
                }).ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        

    }
}
