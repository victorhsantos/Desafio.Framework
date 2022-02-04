using System.Collections.Generic;

namespace Desafio.Framework.BLL.Operacoes
{
    public interface IOperacoes
    {        
        IEnumerable<int> NumerosDivisores(int n);
        IEnumerable<int> NumerosPrimos(int n);
        IEnumerable<int> NumerosDivisoresPrimos(int n);
    }
}
