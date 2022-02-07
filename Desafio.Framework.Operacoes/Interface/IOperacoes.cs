using System.Collections.Generic;

namespace Desafio.Framework.BLL.Operacoes
{
    public interface IOperacoes
    {        
        public List<int> NumerosDivisores(int n);
        public List<int> NumerosPrimos(int n);
        public List<int> NumerosDivisoresPrimos(int n);
    }
}
