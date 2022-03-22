using System;
using CsvHelper.Configuration.Attributes;

namespace projectCSVHelper.src.Entities
{
    public class Programa
    {
        public string Nome { get; set; }
        public string Apresentador { get; set; }
        // [Name("salario")]
        // [CultureInfo("pt-BR")]
        public double Salario { get; set; }
        [Name("DataLançamento")]
        // [Format("dd/MM/yyyy")]
        public DateTime Datalancamento { get; set; }
    }
}
