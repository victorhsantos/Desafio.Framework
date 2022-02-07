using Desafio.Framework.Api.Controllers;
using Desafio.Framework.BLL.Operacoes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Desafio.Framework.Tests
{
    public class OperacoesControllerDivisoresPrimos
    {
        [Fact]
        public void DadaDivisoresPrimosComInformacoesValidasDeveRetornarOk200()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);
            var numeroDivisores = 1;

            //act
            var retorno = controlador.DivisoresPrimos(numeroDivisores);

            //assert
            Assert.IsType<OkObjectResult>(retorno); //200
        }

        [Fact]
        public void DadaDivizoresPrimosComValorZeradoDeveRetornarNotFound404()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);
            var numeroDivisores = 0;

            //act
            var retorno = controlador.DivisoresPrimos(numeroDivisores);

            //assert
            Assert.IsType<NotFoundResult>(retorno); //404
        }

        [Theory]
        [MemberData(nameof(resultDivisores))]
        public void DadoNumeroDeEntradoResultadoDeveConterNumerosEsperados(int numDivisor, List<int> resultadoEsperado)
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);

            //act
            var retorno = controlador.DivisoresPrimos(numDivisor);

            //assert            
            var result = retorno as OkObjectResult;
            Assert.Equal(resultadoEsperado, result.Value);
        }

        public static IEnumerable<object[]> resultDivisores => new List<object[]>
        {
            new object[] { 45, new List<int> { 1, 3, 5 } },
            new object[] { 100, new List<int> { 1, 2, 5 } },
            new object[] { 1, new List<int> { 1 } },
            new object[] { 289, new List<int> { 1, 17 } }

        };
    }
}

