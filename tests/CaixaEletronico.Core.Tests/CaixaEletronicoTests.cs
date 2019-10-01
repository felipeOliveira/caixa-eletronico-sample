using System.Linq;
using CaixaEletronico.Core.Cedulas;
using Xunit;

namespace CaixaEletronico.Core.tests
{
    public class CaixaEletronicoTests
    {
        private CaixaEletronico _caixa;

        public CaixaEletronicoTests()
        {
            _caixa = new CaixaEletronico();
        }

        [Fact(DisplayName = "Quando solicitar para sacar 10 reais o caixa deve devolver uma cédula de 10 reais")]
        public void QuandoSoliciaParaSacar10ReaisOCaixaDeveDevolverUmaCedulaDe10Reais()
        {
            var cedulas = _caixa.Sacar(10);

            Assert.Equal(1, cedulas.Count);
            Assert.Equal(10.00d, cedulas.Sum(celuda=>celuda));
        }

        [Fact(DisplayName = "Quando solicitar para sacar 20 reais o caixa deve devolver uma cédula de 20 reais")]
        public void QuandoSolicitarParaSacar20ReaisOCaixaDeveDevolverDuasCedulasDe10Reais()
        {
            var cedulas = _caixa.Sacar(20);

            Assert.Equal(1, cedulas.Count);
            Assert.Equal(20.00d, cedulas.Sum(cedula => cedula));
        }
        
        
        [Fact(DisplayName = "Quando solicitar para sacar 30 reais o caixa deve devolver uma cedula de 10 e outra de 20 reais")]
        public void QuandoSolicitarParaSacar30ReaisOCaixaDeveDevolverTresCedulasDe10Reais()
        {
            var cedulas = _caixa.Sacar(30);

            Assert.Equal(2, cedulas.Count);
            Assert.Equal(30.00d, cedulas.Sum(cedula => cedula));
        }
        
        [Fact(DisplayName = "Quando solicitar para sacar 40 reais o caixa deve devolver duas cedulas 20 reais")]
        public void QuandoSolicitarParaSacar40ReaisOCaixaDeveDevolverDuasCedulasDe20Reais()
        {
            var cedulas = _caixa.Sacar(40);

            Assert.Equal(2, cedulas.Count);
            Assert.Equal(40.00d, cedulas.Sum(cedula => cedula));
        }

        [Fact(DisplayName =
            "Quando solicitar uma nota de 50 reais o caixa eletronico deve me deolver uma cedula de 50 reais")]
        public void QuandoSolicitarUmaNotaDe50ReaisOCaixaDeveMeDevolverUmaNotaDe50Reais()
        {
            var cedulas = _caixa.Sacar(50);

            Assert.Equal(1, cedulas.Count);
            Assert.Equal(50.00d, cedulas.Sum(cedula => cedula));
        }

        [Theory(DisplayName =
            "Quando solicitar qualquer valor o caixa irá me devolver o valor em menor número de notas possível")]
        [InlineData(150, 2)]
        [InlineData(450, 5)]
        [InlineData(1000, 10)]
        [InlineData(250, 3)]
        public void QuandoSolicitarQualquerValorOCaixaIraMeDevolverOValorEmMenorNumeroDeNotasPossivel(int valorSolicitado, int numeroDeNotas)
        {
            var cedulas = _caixa.Sacar(valorSolicitado);

            Assert.Equal(numeroDeNotas, cedulas.Count);
            Assert.Equal(valorSolicitado, cedulas.Sum(cedula => cedula));
        }
    }
}