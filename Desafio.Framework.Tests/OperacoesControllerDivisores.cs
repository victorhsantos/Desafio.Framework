using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Desafio.Framework.Api.Controllers;
using Desafio.Framework.BLL.Operacoes;
using System.Collections.Generic;

namespace Desafio.Framework.Tests
{
    public class OperacoesControllerDivisores
    {
        [Fact]
        public void DadaDivisoresComInformacoesValidasDeveRetornarOk200()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);
            var numeroDivisores = 1;

            //act
            var retorno = controlador.Divisores(numeroDivisores);

            //assert
            Assert.IsType<OkObjectResult>(retorno); //200
        }

        [Fact]
        public void DadaDivizoresComValorZeradoDeveRetornarNotFound404()
        {
            //arrange
            var mock = new Mock<Operacoes>();
            var controlador = new OperacoesController(mock.Object);
            var numeroDivisores = 0;

            //act
            var retorno = controlador.Divisores(numeroDivisores);

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
            var retorno = controlador.Divisores(numDivisor);

            //assert            
            var result = retorno as OkObjectResult;
            Assert.Equal(resultadoEsperado, result.Value);
        }

        public static IEnumerable<object[]> resultDivisores => new List<object[]>
        {
            new object[] { 45, new List<int> { 1, 3, 5, 9, 15, 45 } },
            new object[] { 100, new List<int> { 1, 2, 4, 5, 10, 20, 25, 50, 100 } },
            new object[] { 1, new List<int> { 1 } },
            new object[] { 289, new List<int> { 1, 17, 289 } }

        };
    }
}
