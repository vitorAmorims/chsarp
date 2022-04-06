using System;
using Strategy.src.Interface;
using Strategy.src.Model;
using Xunit;

namespace Strategy.Tests
{
    public class CalculaImposto
    {
        [Fact(DisplayName="Deve calcular o valor correto de ICMS")]
        public void DeveRetornarOValorDeImpostosCorretosParaICMS()
        {
            //Arrange
            Orcamento orcamento = new Orcamento(1000);
            Imposto icms = new ICMS();
            CalculaImposto_v3 calc = new CalculaImposto_v3();
            
            //Action
            var resultado = calc.RealizarCalculo(orcamento, icms);

            //Assert
            var esperado = 100;
            Assert.Equal(esperado, resultado);
        }
        
        [Fact(DisplayName="Deve calcular o valor correto de ISS")]
        public void DeveRetornarOValorDeImpostosCorretosParaISS()
        {
            //Arrange
            Orcamento orcamento = new Orcamento(1000);
            Imposto iss = new ISS();
            CalculaImposto_v3 calc = new CalculaImposto_v3();
            
            //Action
            var resultado = calc.RealizarCalculo(orcamento, iss);

            //Assert
            var esperado = 60;
            Assert.Equal(esperado, resultado);
        }

        [Fact(DisplayName="Deve calcular o valor correto de ICC 0.5%")]
        public void DeveRetornarOValorDeImpostosCorretosParaICCMeioPorcento()
        {
            //Arrange
            Orcamento orcamento = new Orcamento(999);
            Imposto icc = new ICCCMeioPorcento();
            CalculaImposto_v3 calc = new CalculaImposto_v3();
            
            //Action
            var resultado = calc.RealizarCalculo(orcamento, icc);

            //Assert
            var esperado = 49.95;
            Assert.Equal(esperado, resultado);
        }

        [Fact(DisplayName="Deve calcular o valor correto de ICC 0.7%")]
        public void DeveRetornarOValorDeImpostosCorretosParaICCSetePorcento()
        {
            //Arrange
            Orcamento orcamento = new Orcamento(1000);
            Imposto icc = new ICCCSetePorcento();
            CalculaImposto_v3 calc = new CalculaImposto_v3();
            
            //Action
            var resultado = calc.RealizarCalculo(orcamento, icc);

            //Assert
            var esperado = 70;
            Assert.Equal(esperado, resultado);
        }

        [Fact(DisplayName="Deve calcular o valor correto de ICC 0.8% + 30 Reais")]
        public void DeveRetornarOValorDeImpostosCorretosParaICCOitoPorcentoMaisTrintaReais()
        {
            //Arrange
            Orcamento orcamento = new Orcamento(3100);
            Imposto icc = new ICCCOitoPorcentoMaisTrintaReais();
            CalculaImposto_v3 calc = new CalculaImposto_v3();
            
            //Action
            var resultado = calc.RealizarCalculo(orcamento, icc);

            //Assert
            var esperado = 278;
            Assert.Equal(esperado, resultado);
        }
    }
}
