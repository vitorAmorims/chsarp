using System;
using CsvHelper.Configuration.Attributes;

namespace projectCSVHelper.src.Entities
{
    public class Programa2
    {
        [Index(0)]
        public string Nome { get; set; }
        [Index(1)]
        public string Apresentador { get; set; }
        // [Name("salario")]
        // [CultureInfo("pt-BR")]
        [Index(2)]
        public double Salario { get; set; }
        [Index(3)]
        // [Format("dd/MM/yyyy")]
        public DateTime Datalancamento { get; set; }
    }
}
