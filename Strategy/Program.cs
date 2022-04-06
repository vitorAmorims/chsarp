using System;
using Strategy.src.Interface;
using Strategy.src.Model;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("----------Abaixo de 500----------------");
            //arrange
            CalculadorDeDescontos calculaDescontoAbaixoDeQuinhentosReais
                = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(500);
            orcamento.AdicionaItem(new Item("caneta", 250));
            orcamento.AdicionaItem(new Item("lápis", 250));

            //action
            double desconto = calculaDescontoAbaixoDeQuinhentosReais.Calcula(orcamento);
            System.Console.WriteLine(desconto);

            System.Console.WriteLine("-------------------Maior que 500 desconto 7%----------------------");
            //arrange
            CalculadorDeDescontos calculaDescontoMaiorQuinhentosReais
                = new CalculadorDeDescontos();
            Orcamento orcamento3 = new Orcamento(1500);
            orcamento3.AdicionaItem(new Item("caneta", 1250));
            orcamento3.AdicionaItem(new Item("lápis", 250));

            //action
            double desconto3 = calculaDescontoMaiorQuinhentosReais.Calcula(orcamento3);
            System.Console.WriteLine(desconto3);

            System.Console.WriteLine("--------------Mais de cinco itens  10%-----------------");
            //arrange
            CalculadorDeDescontos calcularDescontoMaisDeCincoItens =
            new CalculadorDeDescontos();
            Orcamento orcamento2 = new Orcamento(1000);
            orcamento2.AdicionaItem(new Item("caneta", 250));
            orcamento2.AdicionaItem(new Item("lápis", 250));
            orcamento2.AdicionaItem(new Item("Microondas", 250));
            orcamento2.AdicionaItem(new Item("Carregador de Celular", 100));
            orcamento2.AdicionaItem(new Item("Fone de ouvido", 100));
            orcamento2.AdicionaItem(new Item("Pilhas", 50));

            //action
            double desconto2 = calcularDescontoMaisDeCincoItens.Calcula(orcamento2);
            System.Console.WriteLine(desconto2);


        }
        public static void IniciandoStrategy()
        {
            Orcamento o = new Orcamento(10);
            //primeira versão ifs aninhados
            CalculadorDeImpostos_v1 calcularICMS_v1 = new CalculadorDeImpostos_v1(o, "ICMS");
            CalculadorDeImpostos_v1 calcularISS_v1 = new CalculadorDeImpostos_v1(o, "ISS");
        }
        public static void IntermediarioStrategy()
        {
            Orcamento o = new Orcamento(10);
            //segunda versão - varios métodos
            CalculadoraImposto_v2 calcularICMS_v2 = new CalculadoraImposto_v2();
            calcularICMS_v2.RealizarCalculoICMS(o);
            CalculadoraImposto_v2 calcularISS_v2 = new CalculadoraImposto_v2();
            calcularISS_v2.RealizarCalculoISS(o);
        }

        public static void StrategyImplementado()
        {
            Orcamento o = new Orcamento(10);
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
