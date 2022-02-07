using System;
using System.Collections.Generic;

namespace Desafio.Framework.BLL.Operacoes
{
    public class Operacoes : IOperacoes
    {
        IEnumerable<int> IOperacoes.NumerosDivisores(int n)
        {
            if (n == 0)
                return null;

            var numerosDivisores = new List<int>() { 1 };

            for (int i = 2; i <= n; i++)
                if (EhDivisor(i, n))
                    numerosDivisores.Add(i);

            return numerosDivisores;

        }

        IEnumerable<int> IOperacoes.NumerosPrimos(int n)
        {

            if (n == 0)
                return null;

            var numerosPrimos = new List<int>() { 1 };

            for (int i = 2; i <= n; i++)
                if (EhPrimo(i))
                    numerosPrimos.Add(i);

            return numerosPrimos;

        }

        IEnumerable<int> IOperacoes.NumerosDivisoresPrimos(int n)
        {
            if (n == 0)
                return null;

            var numerosPrimos = new List<int>() { 1 };

            for (int i = 2; i <= n; i++)
                if (EhDivisor(i, n) && EhPrimo(i))
                    numerosPrimos.Add(i);

            return numerosPrimos;

        }

        private bool EhDivisor(int numTesteDivisor, int numDivisor)
        {
            var resto = numDivisor % numTesteDivisor;
            if (resto == 0)
                return true;

            return false;
        }

        private bool EhPrimo(int numTestePrimo)
        {
            bool ehPrimo = true;

            for (int i = 2; i <= numTestePrimo / 2; i++)
                if (numTestePrimo % i == 0)
                {
                    ehPrimo = false;
                    break;
                }

            return ehPrimo;
        }
    }
}
