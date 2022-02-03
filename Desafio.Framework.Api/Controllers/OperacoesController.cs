using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.Framework.Api.Controllers
{
    
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    public class OperacoesController : ControllerBase
    {
        [HttpGet("/divisores")]
        [SwaggerOperation(Summary = "")]
        //[ProducesResponseType(statusCode: 200, Type = typeof(LivroApi))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Divisores([FromBody] int numero)
        {
            var model = (id);

            if (model == null)            
                return NotFound();
            
            return Ok(model.ToApi());
        }
    }
}
