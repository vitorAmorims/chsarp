using System;
using Strategy.src.Model;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Orcamento o = new Orcamento(10);
            CalculadorDeImpostos_v1 calcularICMS_v1 = new CalculadorDeImpostos_v1(o, "ICMS");
            CalculadorDeImpostos_v1 calcularISS_v1 = new CalculadorDeImpostos_v1(o, "ISS");

        }
    }
}
