using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class CalculadorDeDescontos
    {
        public double Calcula(Orcamento orcamento)
        {
            Desconto d1 = new DescontoPorCincoItens();
            Desconto d2 = new DescontoPorMaisDeQuinhentosReais();
            Desconto d3 = new SemDesconto();

            d1.Proximo = d2;
            d2.Proximo = d3;

            return d1.Desconta(orcamento);

            //parte 2
            // double desconto = new DescontoPorCincoItens().Desconta(orcamento);
            // if(desconto == 0)
            // {
            //     desconto = new DescontoPorMaisDeQuinhentosReais().Desconta(orcamento);
            // }
            // return desconto;

            //parte 1
            // if(orcamento.Itens.Count > 5)
            // {
            //     return orcamento.Valor * 0.1;
            // }
            // if(orcamento.Valor > 500)
            // {
            //     return orcamento.Valor * 0.07;
            // }
            // return 0;
        }
    }
}
