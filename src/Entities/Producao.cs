using System;

namespace projectCSVHelper.src.Entities
{
    public class Producao
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
