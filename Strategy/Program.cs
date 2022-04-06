using System;
using Strategy.src.Interface;
using Strategy.src.Model;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Orcamento o = new Orcamento(10);
            //primeira versão ifs aninhados
            // CalculadorDeImpostos_v1 calcularICMS_v1 = new CalculadorDeImpostos_v1(o, "ICMS");
            // CalculadorDeImpostos_v1 calcularISS_v1 = new CalculadorDeImpostos_v1(o, "ISS");

            //segunda versão - varios métodos
            // CalculadoraImposto_v2 calcularICMS_v2 = new CalculadoraImposto_v2();
            // calcularICMS_v2.RealizarCalculoICMS(o);
            // CalculadoraImposto_v2 calcularISS_v2 = new CalculadoraImposto_v2();
            // calcularISS_v2.RealizarCalculoISS(o);

            //terceira versão - Strategy
            Imposto icms = new ICMS();
            Imposto iss = new ISS();
            Imposto icccMeioPorcento = new ICCCMeioPorcento();
            Imposto icccSetePorcento = new ICCCSetePorcento();
            Imposto icccOitoPorcentoMaisTrintaReais = new ICCCOitoPorcentoMaisTrintaReais();
            CalculaImposto_v3 calc = new CalculaImposto_v3() ;
            calc.RealizarCalculo(o, icms);
            calc.RealizarCalculo(o, iss);
            calc.RealizarCalculo(o, icccMeioPorcento);
            calc.RealizarCalculo(o, icccSetePorcento);
            calc.RealizarCalculo(o, icccOitoPorcentoMaisTrintaReais);

        }
    }
}
