using System;

namespace Desafio.Framework.Api.Models
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string Tipo { get; set; }

        /// <summary>
        /// Modelo de Retorno para Erro
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static ErrorResponse From(Exception ex)
        {
            if (ex == null)
                return null;

            return new ErrorResponse
            {
                Codigo = ex.HResult,
                Mensagem = ex.Message,
                InnerError = From(ex.InnerException),
                Tipo = ex.GetType().Name
            };
        }
    }
}
