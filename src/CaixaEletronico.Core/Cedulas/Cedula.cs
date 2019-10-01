using System.Dynamic;
using System.Runtime.InteropServices;
using System.Xml;

namespace CaixaEletronico.Core.Cedulas
{
    public class Cedula
    {

        protected double Valor;

        public Cedula(double value)
        {
            Valor = value;
        }

        public static implicit operator double(Cedula cedula)
        {
            return cedula.Valor;
        }

        public override string ToString()
        {
            return Valor.ToString("C");
        }
    }
}