using Clinica.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        private readonly IRegionApp _Region;
        public RegionController(IRegionApp RegionApp)
        {
            _Region = RegionApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _Region.Collection();
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
