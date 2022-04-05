using System;

namespace Strategy.src.Model
{
    public class CalculadorDeImpostos_v1
    {
        //baixa coesao
        public CalculadorDeImpostos_v1(Orcamento orcamento, string imposto)
        {
            //problema - anihamento de ifs    
            // if ("ICMS".Equals(imposto))
            // {
            //     double icms = orcamento.Valor * 0.1;
            //     System.Console.WriteLine(icms);
            // }

            // if ("ISS".Equals(imposto))
            // {
            //     double iss = orcamento.Valor * 0.06;
            //     System.Console.WriteLine(iss);
            // }

            // if ("ICMS".Equals(imposto))
            // {
            //     double icms = new ICMS().CalculaICMS(orcamento);
            //     System.Console.WriteLine(icms);
            // }

            // if ("ISS".Equals(imposto))
            // {
            //     double iss = new ISS().CalculaISS(orcamento);
            //     System.Console.WriteLine(iss);
            // }


        }
    }
}
