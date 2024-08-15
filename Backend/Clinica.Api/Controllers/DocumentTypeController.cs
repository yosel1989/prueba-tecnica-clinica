using Clinica.Application.Interface;
using Clinica.Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/document-type")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {

        private readonly IDocumentTypeApp _DocumentType;
        public DocumentTypeController(IDocumentTypeApp DocumentTypeApp)
        {
            _DocumentType = DocumentTypeApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _DocumentType.Collection();
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


    }
}
