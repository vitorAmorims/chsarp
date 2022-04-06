using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class DescontoPorMaisDeQuinhentosReais : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Valor > 500)
            {
                return orcamento.Valor * 0.07;
            }
            
            return Proximo.Desconta(orcamento);
        }
    }
}
