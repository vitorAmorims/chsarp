using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex5
{
    public class Exemplo5
    {
        public List<Pokemon> Pokemons = new List<Pokemon>
            {
                new Pokemon("Ratata", 21 ),
                new Pokemon("Pidgeotto", 52 ),
                new Pokemon("Pidgey", 14 ),
                new Pokemon("Zubat", 25 ),
                new Pokemon("Pikachu", 33),
                new Pokemon("Entei", 115)
            };
        public IEnumerable<string> RetornarNomePokemonMenosResistente()
        {
            var menorResistencia = Pokemons.Min(p => p.HP);

            var resultado = from p in Pokemons
                            where p.HP == menorResistencia
                            select p.Nome;

            return resultado;
        }

        public IEnumerable<string> DeveNomePokemonMaisResistente()
        {
            var NotaMaisResistente = Pokemons.Max(p => p.HP);

            var query = from p in Pokemons
                        where p.HP == NotaMaisResistente
                        select p.Nome;

            return query;
        }

        public double RetornarAMediaDeResistencia()
        {
            var query = Pokemons.Average(p => p.HP);
            return query;
        }

        public IEnumerable<string> RetornarONomeDeMaiorResistenciaQueNaoTemP()
        {

            var maiorResistenciaNaoP = Pokemons
                .Where(p => !p.Nome.StartsWith("P"))
                .Max(p => p.HP);

            var query = Pokemons
                .Where(p => p.HP == maiorResistenciaNaoP)
                .Select(p => p.Nome);

            return query;
        }

        public IEnumerable<string> RetornarNomeMenorResistenciaQueComeceComP()
        {
            var nota = Pokemons.Where(p => p.Nome.StartsWith("P")).Min(p => p.HP);

            var nome = from p in Pokemons
                       where p.HP == nota
                       select p.Nome;
            return nome;
        }

        public decimal RetornarAMediana()
        {
            int contagem = Pokemons.Count();
            var ordenado = Pokemons.OrderBy(p => p.HP);
            var elementoCentral_1 = ordenado.Skip((contagem - 1) / 2).First().HP;
            var elementoCentral_2 = ordenado.Skip(contagem / 2).First().HP;
            decimal mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            return mediana;
        }
    }
    // public static decimal Mediana(IQueryable origem)
    // {
    //     int contagem = origem.Count();
    //     var ordenado = origem.OrderBy(p => p);
    //     var elementoCentral_1 = ordenado.Skip((contagem - 1) / 2).First();
    //     var elementoCentral_2 = ordenado.Skip(contagem / 2).First();
    //     decimal mediana = (elementoCentral_1 + elementoCentral_2) / 2;
    //     return mediana;
    // }

    public class Pokemon
    {
        public string Nome { get; set; }
        public int HP { get; set; }

        public Pokemon(string nome, int hP)
        {
            Nome = nome;
            HP = hP;
        }
    }
}
