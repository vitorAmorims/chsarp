using System;
using Xunit;

namespace Ex6.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void RetornarPrimeiroTipoSanguineo()
        {
            var objEx6 = new Exemplo6();
            var resultado = objEx6.RetornarPrimeiroTipoSanguineo();
            string esperado = "A";
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void RetornarSegundoTipoSanguineo()
        {
            var Exobj6 = new Exemplo6();
            var resultado = Exobj6.RetornarSegundoTipoSanguineo();
            string esperado = "B";
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void RetornarOUltimoTipoSanguineo()
        {
            var objEx6 = new Exemplo6();
            var resultado = objEx6.RetornarOUltimoTipoSanguineo();
            Assert.Equal("O", resultado);
        }
    }
}
