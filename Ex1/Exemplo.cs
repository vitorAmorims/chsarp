using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    public class Exemplo
    {
        public IEnumerable<string> ListaDeMusicasEGeneros()
        {
            var listaDeMusicas = ListaDeMusicas();
            var listaDeGeneros = ListaDeGeneros();

            var queryMusicaGenero = from m in listaDeMusicas
            join g in listaDeGeneros on m.CategoriaId equals g.Id
            select g.Nome;

            System.Console.WriteLine("Imprime na tela o nome do gênero que possui join com música!!");
            foreach (var item in queryMusicaGenero)
            {
                System.Console.WriteLine($"{item}");
            }

            return queryMusicaGenero;
        }

        public List<Atleta> ListaDeAtletas()
        {
            List<Atleta> atletas = new List<Atleta>()
                {
                    new Atleta(1,"JAM","BOLT Usain",9.81f),
                    new Atleta ( 2, "USA", "GATLIN Justin", 9.89f ),
                    new Atleta ( 3, "CAN", "DE GRASSE Andre", 9.91f ),
                    new Atleta ( 4, "JAM", "BLAKE Yohan", 9.93f ),
                    new Atleta ( 5, "RSA", "SIMBINE Akani", 9.94f ),
                    new Atleta ( 6, "CIV", "MEITE Ben Youssef", 9.96f ),
                    new Atleta ( 7, "FRA", "VICAUT Jimmy", 10.04f ),
                    new Atleta ( 8, "USA", "BROMELL Trayvon", 10.06f )
                };
            return atletas;
        }
        public List<Genero> ListaDeGeneros()
        {
            List<Genero> generos = new List<Genero>
                {
                    new Genero (1, "Rock" ),
                    new Genero (2, "Reggae" ),
                    new Genero (3, "Rock Progressivo" ),
                    new Genero (4, "Jazz" ),
                    new Genero (5, "Punk Rock" ),
                    new Genero (6, "Classica" )
                };
            return generos;
        }
        public List<Musica> ListaDeMusicas()
        {
            List<Musica> musicas = new List<Musica>
                {
                    new Musica (1, "Sweet Child O'Mine", 1 ),
                    new Musica (2, "I Shot The Sheriff", 2 ),
                    new Musica (3, "Danúbio Azul", 6 ),
                };
            return musicas;
        }
    }

    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }

        public Musica(int id, string nome, int categoriaId)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
        }
    }

    public class Genero
    {
        public int Id;
        public string Nome;

        public Genero(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
    }

    public class Atleta
    {
        public int Posicao { get; set; }
        public string CodigoPais { get; set; }
        public string Nome { get; set; }
        public float Tempo { get; set; }

        public Atleta(int posicao, string codigoPais, string nome, float tempo)
        {
            this.Posicao = posicao;
            this.CodigoPais = codigoPais;
            this.Nome = nome;
            this.Tempo = tempo;

        }
    }
}
