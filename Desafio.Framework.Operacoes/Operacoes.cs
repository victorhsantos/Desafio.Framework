using Desafio.Framework.BLL.Operacoes;
using System;
using System.Collections.Generic;

namespace Desafio.Framework.Operacoes
{
    public class Operacoes : IOperacoes
    {

        IList<int> IOperacoes.NumerosDivisores(int n)
        {
            if (n == 0)
                throw new Exception("Não existe divisores entre zero.");

            var numerosDivisores = new List<int>();

            for (int i = 1; i <= n; i++)
                if (EhDivisor(i, n))
                    numerosDivisores.Add(i);

            return numerosDivisores;

        }

        IList<int> IOperacoes.NumerosPrimos(int n)
        {
            if (n == 0)
                throw new Exception("Não existe numeros primos entre zero.");

            var numerosPrimos = new List<int>() { 1 };

            for (int i = 2; i <= n; i++)
                if (EhPrimo(i))
                    numerosPrimos.Add(i);

            return numerosPrimos;

        }

        private bool EhDivisor(int numTesteDivisor, int numDivisor)
        {
            if (numTesteDivisor == 0)
                throw new Exception("Não é possivel calcular os a divisão por zero.");

            var resto = numTesteDivisor % numDivisor;
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
