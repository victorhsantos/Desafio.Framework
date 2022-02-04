using Microsoft.AspNetCore.Mvc;

namespace Desafio.Framework.Api.Autenticacao.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "NomeUsuario = Framework / Senha = 123")]
        [ProducesResponseType(statusCode: 200, Type = typeof(string))]
        [ProducesResponseType(statusCode: 401)]
        public IActionResult Login([FromBody, SwaggerParameter(Required = true)] Usuario loginDetalhes)
        {
            //bool resultado = ValidarUsuario(loginDetalhes);
            bool resultado = true;
            if (resultado)
            {
                var tokenString = GerarTokenJWT(loginDetalhes.NomeUsuario);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();

        }
        private string GerarTokenJWT(string userRequest)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var issuer = "Desafio.Framework";
            //var audience = "Postman";
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("desafio-framework-dotnet-authentication-valid"));




            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var timeExpires = DateTime.Now.AddMinutes(30);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userRequest),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                signingCredentials: credentials,
                expires: timeExpires);


            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            return stringToken;
        }
        private bool ValidarUsuario(Usuario loginDetalhes)
        {
            if (loginDetalhes.NomeUsuario == "Framework" && loginDetalhes.Senha == "123")
                return true;

            return false;

        }
    }
}
