using Clinica.Application.Interface;
using Clinica.Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserApp _User;
        public UserController(IUserApp UserApp)
        {
            _User = UserApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _User.Collection();
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

        [HttpPost]
        public async Task<ActionResult> Registrar(UserDTO model)
        {

            try
            {
                await _User.Create(model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Modificar(UserDTO model)
        {
            try
            {
                await _User.Update(model);
                return Ok(new
                {
                    data = new { },
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


        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(string id)
        {
            try
            {
                await _User.Delete(id);
                return Ok(new
                {
                    data = new { },
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Buscar(string id)
        {
            try
            {
                var data = await _User.Find(id);
                return Ok(new
                {
                    data = data,
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
