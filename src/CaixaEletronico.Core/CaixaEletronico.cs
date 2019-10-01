using System.Collections.Generic;
using CaixaEletronico.Core.Cedulas;

namespace CaixaEletronico.Core
{
    public class CaixaEletronico
    {
        public IReadOnlyList<Cedula> Sacar(int valor)
        {
            var cedulaValorArpoximado = 0;
            var restante = valor;

            var cedulas = new List<Cedula>();

            do
            {
                cedulaValorArpoximado = ObterCedulaDeMaiorValorAproximado(restante);
                restante -= cedulaValorArpoximado;
                cedulas.Add(new Cedula(cedulaValorArpoximado));

            } while (restante > 0);

            return cedulas;
        }

        private static int ObterCedulaDeMaiorValorAproximado(int valor)
        {
            return valor switch
            {
                int v when v == 10 || v < 20 => 10,
                int v when v == 20 || v < 50 => 20,
                int v when v == 50 || v < 100 => 50,
                _ => 100
            };
        }
    }
}