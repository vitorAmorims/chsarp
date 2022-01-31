using System;
using System.Collections.Generic;
using Xunit;

namespace Ex3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveRetornarPrimeiroIdENomeDaMusica()
        {
            var objEx3 = new Exemplo3();
            var resultado = objEx3.RetornarDicionarioComIdENomeDaMusica();

            IDictionary<int, string> dicionarioIdEMusica = new Dictionary<int, string>();
            dicionarioIdEMusica.Add(1154, "Sweet Child O' Mine");

            Assert.Equal(dicionarioIdEMusica[1154], resultado[1154]);

        }

        [Fact]
        public void DeveRetornarIdMusicaNomeMusicaNomeGenero()
        {
            var objEx3 = new Exemplo3();
            var resultado = objEx3.RetornarIdNomeMusicaENomeGenero();

            System.Console.WriteLine("Deve retornar string com Id da Musica, Nome da Musica e Nome do Genero");
            foreach (var item in resultado)
            {
                System.Console.WriteLine(item);
            }

            List<string> Esperado = new List<string>{
                "1154 - Rock - Rock",
                "900 - Reggae - Reggae",
                "3445 - Classica - Classica"
            };

            for (var i = 0; i < resultado.Count; i++)
            {
                Assert.Equal(Esperado[i], resultado[i]);
            }
        }
    }
}
