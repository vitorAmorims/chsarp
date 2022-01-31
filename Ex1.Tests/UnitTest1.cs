using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Ex1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DevePossuirDoisAtletasJamaicanos()
        {
            var objExemplo = new Exemplo();
            var resultado = objExemplo.ListaDeAtletas();

            var atleta = from a in resultado
                         where a.CodigoPais == "JAM"
                         select a;

            var pais = "JAM";

            foreach (var a in atleta)
            {
                System.Console.WriteLine(a.CodigoPais);
                Assert.Contains(pais, a.CodigoPais);
            }

            Assert.Equal(2, atleta.Count());
        }

        [Fact]
        public void DeveRetornarSomenteGenerosComRock()
        {
            var objExemplo = new Exemplo();
            var listaGeneros = objExemplo.ListaDeGeneros();

            var resultado = from genero in listaGeneros
                            where genero.Nome.Contains("Rock")
                            select genero;

            System.Console.WriteLine("Lista de gêneros com Rock");
            foreach (var item in resultado)
            {
                System.Console.WriteLine(item.Nome);
            }

            Assert.Equal(3, resultado.Count());
        }

        [Fact]
        public void DeveRetornarNomesDasMusicasComCategoriaIdIgualHaUm()
        {
            var objExemplo = new Exemplo();
            var listaDeMusicas = objExemplo.ListaDeMusicas();

            var resultado = from musica in listaDeMusicas
                            where musica.CategoriaId == 1
                            select musica.Nome;

            System.Console.WriteLine("Nome de Músicas com categoria ID igual a 1");
            foreach (var m in resultado)
            {
                System.Console.WriteLine(m);
            }
            Assert.Equal(1, resultado.Count());
        }

        [Fact]
        public void DeveRetornarOsNomesDasMusicasPorIdDeGenero()
        {
            var objExemplo = new Exemplo();
            var listaDeMusicas = objExemplo.ListaDeMusicas();

            var query = from musica in listaDeMusicas
                        .Where(m => m.CategoriaId.Equals(1))
                        .Select(m => m.Nome)
                        select (musica);

            System.Console.WriteLine("NomeDasMusicasPorGeneroNumeroUm");
            foreach (var item in query)
            {
                System.Console.WriteLine(item);
                Assert.Equal("Sweet Child O'Mine", item);
            }
        }

        [Fact]
        public void DeveRetornarOsNomesDasGeneros()
        {
            var objExemplo = new Exemplo();
            var EnumerableNomes = objExemplo.ListaDeMusicasEGeneros();

            var nomesDasMusicas = new List<string>{ "Rock", "Reggae", "Classica" };

            var resultado1 = EnumerableNomes.FirstOrDefault(n => n == "Rock").ToString();

            var resultado2 = EnumerableNomes.FirstOrDefault(n => n == "Classica").ToString();

            Assert.Contains(nomesDasMusicas[0].ToString(), resultado1);
            Assert.Contains(nomesDasMusicas[2].ToString(), resultado2);
        }

    }
}
