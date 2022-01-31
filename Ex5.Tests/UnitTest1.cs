using System;
using Xunit;
using System.Linq;

namespace Ex5.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveRetornarOPokemonMenosResistente()
        {
            var objEx5 = new Exemplo5();
            var resultado = objEx5.RetornarNomePokemonMenosResistente();

            var esperado = "Pidgey";
            
            Assert.Equal(esperado, string.Join("", resultado));

        }
        [Fact]
        public void DeveRetornarONomeDoPokemonDeMaiorResistencia()
        {
            var objEx5 = new Exemplo5();
            var resultado  = objEx5.DeveNomePokemonMaisResistente();
            var esperado = "Entei";
            Assert.Equal(esperado, string.Join("", resultado));
        }

        [Fact]
        public void DeveRetornarAMediaDeResistencia()
        {
            var objEx5 = new Exemplo5();
            var resultado = objEx5.RetornarAMediaDeResistencia();

            Assert.Equal(43.333333333333336, resultado);
        }

        [Fact]
        public void DeveRetornarONomeDeMaiorResistenciaQueNaoTenhaLetraP()
        {
            var objEx5 =new Exemplo5();
            var resultado = objEx5.RetornarONomeDeMaiorResistenciaQueNaoTemP();

            Assert.Equal("Entei", string.Join("", resultado));
        }

        [Fact]
        public void DeveretornarONomeDeMenorResistenciaQueComeceLetraP()
        {
            var objEx5 = new Exemplo5();
            var resultado = objEx5.RetornarNomeMenorResistenciaQueComeceComP();
            Assert.Equal("Pidgey", string.Join("", resultado));
        }

        [Fact]
        public void DeveRetornarAMediana()
        {
            var objEx5 = new Exemplo5();
            var resultado = objEx5.RetornarAMediana();
            Assert.Equal(29, resultado);
        }
    }
}
