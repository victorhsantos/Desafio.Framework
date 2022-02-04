using System.ComponentModel.DataAnnotations;

namespace Desafio.Framework.Api.Models
{
    public class ParametrosOperacoes
    {
        [Required]
        public int Numero { get; set; }
    }
}
