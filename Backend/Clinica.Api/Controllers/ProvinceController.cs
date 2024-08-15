using Clinica.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/province")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {

        private readonly IProvinceApp _Province;
        public ProvinceController(IProvinceApp ProvinceApp)
        {
            _Province = ProvinceApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _Province.Collection();
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


        [HttpGet("region/{regioncode}")]
        public async Task<ActionResult> Listar(string regioncode)
        {
            try
            {
                var lista = await _Province.CollectionByRegion(regioncode);
                return Ok(new
                {
                    data = lista,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


    }
}
