using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex6
{
    public class Exemplo6
    {
        public IEnumerable<TipoSanguineo> tiposSanguineos = new List<TipoSanguineo>
        {
            new TipoSanguineo ("A"),
            new TipoSanguineo ("B"),
            new TipoSanguineo ("AB"),
            new TipoSanguineo ("O")
        };

        public string RetornarPrimeiroTipoSanguineo()
        {
            var tipoSanguineo = tiposSanguineos.First();
            System.Console.WriteLine(tipoSanguineo.Codigo);
            return string.Join("", tipoSanguineo.Codigo);
        }

        public string RetornarSegundoTipoSanguineo()
        {
            // var pokemon = LinqExtensions.Second(tiposSanguineos);
            var tipo = tiposSanguineos.Second();
            return tipo.Codigo.ToString();
        }

        public string RetornarOUltimoTipoSanguineo()
        {
            var tipo = tiposSanguineos.Last();
            return tipo.Codigo.ToString();
        }
    }

    static class LinqExtensions
    {
        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(1).First();
        }
    }

    public class TipoSanguineo
    {
        public string Codigo { get; set; }
        public TipoSanguineo(string codigo)
        {
            this.Codigo = codigo;
        }
    }

}
