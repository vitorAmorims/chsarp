using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex4
{
    public class Exemplo4
    {
        public List<Genero> generos = new List<Genero>
        {
            new Genero { Id = 1, Nome = "Rock" },
            new Genero { Id = 2, Nome = "Reggae" },
            new Genero { Id = 3, Nome = "Rock Progressivo" },
            new Genero { Id = 4, Nome = "Jazz" },
            new Genero { Id = 5, Nome = "Punk Rock" },
            new Genero { Id = 6, Nome = "Classica" }
        };

        public List<Musica> musicas = new List<Musica>
        {
            new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
            new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
            new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 },
            new Musica { Id = 4, Nome = "Crazy Train", GeneroId = 1 },
            new Musica { Id = 5, Nome = "True Love", GeneroId = 2 }
        };
        public IList<string> RetornarIdENomeMusicaENomeGenero()
        {
            var query = from m in musicas
                        join g in generos on m.GeneroId equals g.Id
                        select new { id = m.Id, NomeMusica = m.Nome, NomeGenero = g.Nome };

            List<string> dadosDeRetorno = new List<string>();

            foreach (var item in query)
            {
                System.Console.WriteLine("{0}\t{1}\t{2}", item.id, item.NomeMusica, item.NomeGenero);
                dadosDeRetorno.Add(string.Concat(item.id, '-', item.NomeMusica, '-', item.NomeGenero));
            }

            return dadosDeRetorno;
        }

        public IList<string> RetornarOrdenadosDecrescenteGeneroCrescenteMusica()
        {
            var MusicasEGenero = new List<string>();
            var query = from m in musicas
                        join g in generos
                        on m.GeneroId equals g.Id
                        select new
                        {
                            NomedaMusica = m.Nome,
                            NomeDoGenero = g.Nome
                        };

            query = query.OrderByDescending(mg => mg.NomeDoGenero).ThenBy(mg => mg.NomedaMusica);

            foreach (var item in query)
            {
                System.Console.WriteLine("{0}-{1}", item.NomedaMusica, item.NomeDoGenero);
                MusicasEGenero.Add($"{item.NomedaMusica}-{item.NomeDoGenero}");
            }

            return MusicasEGenero;
        }

        public IDictionary<string, int> RetornarNumerodeMusicasPorGenero()
        {
            IDictionary<string, int> NumeroDeMusicasPorGenero = new Dictionary<string, int>();
            // NumeroDeMusicasPorGenero.Add("Rock", 1);

            var query = from m in musicas
                        join g in generos on m.GeneroId equals g.Id
                        group g by g into agrupado
                        select new
                        {
                            NomeGenero = agrupado.Key.Nome,
                            Quantidade = agrupado.Count()
                        };

            foreach (var i in query)
            {
                System.Console.WriteLine("{0},{1}", i.NomeGenero, i.Quantidade);
                NumeroDeMusicasPorGenero.Add(i.NomeGenero, i.Quantidade);
            }

            return NumeroDeMusicasPorGenero;
        }

        public int RetornarOTotalDeMusicas()
        {
            var soma = musicas.Count();
            return soma;

        }

        public IList<string> RetornarNomesMusicaEGeneroOrdenadosPorGenero()
        {
            List<string> MusicasEGeneros = new List<string>();

            var query = from m in musicas
                        join g in generos
                        on m.GeneroId equals g.Id
                        orderby g.Nome, m.Nome
                        select new
                        {
                            NomedaMusica = m.Nome,
                            NomeDoGenero = g.Nome
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0}-{1}", item.NomedaMusica, item.NomeDoGenero);
                var StringParaAdicionar = $"{item.NomedaMusica}-{item.NomeDoGenero}";
                MusicasEGeneros.Add(StringParaAdicionar);
            }

            return MusicasEGeneros;
        }
    }

    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
