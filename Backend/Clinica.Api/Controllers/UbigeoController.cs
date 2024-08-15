using Clinica.Application.Interface;
using Clinica.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/ubigeo")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {

        private readonly IUbigeoApp _Ubigeo;
        public UbigeoController(IUbigeoApp UbigeoApp)
        {
            _Ubigeo = UbigeoApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _Ubigeo.Collection();
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



        [HttpGet("region/{regioncode}/province/{provincecode}")]
        public async Task<ActionResult> Listar(string regioncode, string provincecode)
        {
            try
            {
                var lista = await _Ubigeo.CollectionByRegionByProvince(regioncode, provincecode);
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
