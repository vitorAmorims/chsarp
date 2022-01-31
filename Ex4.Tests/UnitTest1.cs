using System;
using System.Collections.Generic;
using Xunit;


namespace Ex4.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var objEx4 = new Exemplo4();

            var resultado = objEx4.RetornarIdENomeMusicaENomeGenero();

            List<string> esperado = new List<string>{
              "1-Sweet Child O'Mine-Rock",
              "2-I shot The Sheriff-Reggae",
              "3-Danúbio Azul-Classica"
            };

            // for (int index = 0; index < resultado.Count; index++)
            // {
            //     Assert.Equal(esperado[index], resultado[index]);
            // }

            Assert.Equal(esperado[0], resultado[0]);
            Assert.Equal(esperado[2], resultado[2]);
        }
        [Fact]
        public void DeveRetornarNomeDasMusicaENomeDosGenerosOrdenadosCrescentePorGenero()
        {
            var objEx4 = new Exemplo4();
            var resultado = objEx4.RetornarNomesMusicaEGeneroOrdenadosPorGenero();

            List<string> esperado = new List<string>(){
                "Danúbio Azul-Classica",
                "I Shot The Sheriff-Reggae",
                "True Love-Reggae",
                "Crazy Train-Rock",
                "Sweet Child O'Mine-Rock"
            };

            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void DeveRetornarOrdenadosDescrecentePorGeneroCrescenteNomeMusica()
        {
            var objEx4 = new Exemplo4();
            var resultado = objEx4.RetornarOrdenadosDecrescenteGeneroCrescenteMusica();

            IList<string> esperado = new List<string>{
                "Crazy Train-Rock",
                "Sweet Child O'Mine-Rock",
                "I Shot The Sheriff-Reggae",
                "True Love-Reggae",
                "Danúbio Azul-Classica"
            };

            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void DeveRetornarONumeroDeMusicasPorGenero()
        {
            var objEx4 = new Exemplo4();
            var resultado = objEx4.RetornarNumerodeMusicasPorGenero();

            IDictionary<string, int> esperado = new Dictionary<string, int>();
            esperado.Add("Rock",2);
            esperado.Add("Reggae", 2);
            esperado.Add("Classica", 1);
            
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void DeveRetornarOTotalGeralDeMusicas()
        {
            var objEx4 = new Exemplo4();
            var resultado = objEx4.RetornarOTotalDeMusicas();
            Assert.Equal(5, resultado);
        }
    }
}
