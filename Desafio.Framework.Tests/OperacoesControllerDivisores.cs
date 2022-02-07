using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Desafio.Framework.Api.Controllers;
using Desafio.Framework.BLL.Operacoes;

namespace Desafio.Framework.Tests
{
    public class OperacoesControllerDivisores
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);
            var numeroDivisores = 45;

            //act
            var retorno = controlador.Divisores(numeroDivisores);

            //assert
            Assert.IsType<OkObjectResult>(retorno); //200
        }

        [Fact]
        public void QuandoExcecaoForLancadaDeveRetornarStatusCode500()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);

            //act
            var retorno = controlador.Divisores(0);

            //assert
            Assert.IsType<NotFoundResult>(retorno); //404
        }
    }
}
