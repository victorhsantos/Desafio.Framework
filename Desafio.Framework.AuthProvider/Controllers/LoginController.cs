﻿using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Desafio.Framework.AuthProvider.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.Framework.AuthProvider.Controllers
{
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
        [SwaggerOperation(Summary = "Valida informacoes de login e retorna um token para a API de Operacoes.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(string))]
        [ProducesResponseType(statusCode: 401)]
        public IActionResult Login([FromBody, SwaggerParameter(Required = true)] Usuario loginDetalhes)
        {
            bool resultado = ValidarUsuario(loginDetalhes);
            if (resultado)
            {
                var tokenString = GerarTokenJWT();
                return Ok(tokenString);
            }

            return Unauthorized();

        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var timeExpires = DateTime.Now.AddMinutes(10);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "Framework"),
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
            //TODO: Implementacao da validacao de usuario
            return true;
        }
    }
}
