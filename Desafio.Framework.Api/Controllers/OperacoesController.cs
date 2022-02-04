using Desafio.Framework.Api.Models;
using Desafio.Framework.BLL.Operacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace Desafio.Framework.Api.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]    
    [Route("api/[controller]")]    
    public class OperacoesController : ControllerBase
    {
        private readonly IOperacoes _operacoes;

        public OperacoesController(IOperacoes operacoes)
        {
            _operacoes = operacoes;
        }

        [HttpGet("divisores")]        
        [SwaggerOperation(Summary = "Verifica todos os divisores que compõem o número.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(IList<int>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Divisores(
            [FromHeader, SwaggerParameter(Required = true)] 
            int numero)
        {
            var numDivisores = _operacoes.NumerosDivisores(numero);
            
            if (numDivisores == null)
                return NotFound();

            return Ok(numDivisores);
        }

        [HttpGet("primos")]
        [SwaggerOperation(Summary = "Verifica todos os primos que compõem o número.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(IList<int>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Primos(
            [FromHeader, SwaggerParameter(Required = true)] 
            int numero)
        {
            var numPrimos = _operacoes.NumerosPrimos(numero);

            if (numPrimos == null)
                return NotFound();

            return Ok(numPrimos);
        }

        [HttpGet("divisores/primos")]
        [SwaggerOperation(Summary = "Verifica todos os divisores primos que compõem o número.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(IList<int>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult DivisoresPrimos(
            [FromHeader, SwaggerParameter(Required = true)] 
            int numero)
        {
            var numPrimos = _operacoes.NumerosDivisoresPrimos(numero);

            if (numPrimos == null)
                return NotFound();

            return Ok(numPrimos);
        }
    }
}
