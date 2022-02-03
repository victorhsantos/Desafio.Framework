using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Framework.BLL.Operacoes
{
    public interface IOperacoes
    {        
        IList<int> NumerosDivisores(int n);
        IList<int> NumerosPrimos(int n);
    }
}
