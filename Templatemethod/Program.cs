using System;
using Templatemethod.src.Model;

namespace Templatemethod
{
    class Program
    {
        static void Main()
        {
            Orcamento orcamento = new Orcamento(1000);
            orcamento.AdicionaItem(new Item("caneta", 500));
            orcamento.AdicionaItem(new Item("celular", 500));

            var icpp = new ICPP();
            var ikcv = new IKCV();
            var ihit = new IHIT();

            ToStringICPP(orcamento, icpp);
            ToStringIKCV(orcamento, ikcv);

            System.Console.WriteLine("IHIT caso 2 itens com o mesmo nome? (imposto 13% + 100) : (1% * número itens do orcamento)");
            System.Console.WriteLine($"orcamento: {orcamento.Valor}");
            var valorDeImpostoIHIT = ihit.Calcula(orcamento);
            foreach (var item in orcamento.Itens)
            {
                System.Console.WriteLine($"\tItem: {item.Nome}, Valor: {item.Valor}");
            }
            System.Console.WriteLine($"resultado IHIT: {valorDeImpostoIHIT}");
            System.Console.WriteLine();

        }

        private static void ToStringIKCV(Orcamento orcamento, IKCV ikcv)
        {
            System.Console.WriteLine("IKCV orçamento maior que 500 e item maior 100? 10% : 6%");
            System.Console.WriteLine($"orcamento: {orcamento.Valor}");
            var valorDeImpostoIKCV = ikcv.Calcula(orcamento);
            foreach (var item in orcamento.Itens)
            {
                System.Console.WriteLine($"\tItem: {item.Nome}, Valor: {item.Valor}");
            }
            System.Console.WriteLine($"resultado: {valorDeImpostoIKCV}");
            System.Console.WriteLine();
        }

        private static void ToStringICPP(Orcamento orcamento, ICPP icpp)
        {
            System.Console.WriteLine("ICPP orçamento maior que 500? 5% : 7%");
            System.Console.WriteLine($"orcamento: {orcamento.Valor}");
            var valorDeImpostoICPP = icpp.Calcula(orcamento);
            System.Console.WriteLine($"resultado: {valorDeImpostoICPP}");
            System.Console.WriteLine();
        }
    }
}
