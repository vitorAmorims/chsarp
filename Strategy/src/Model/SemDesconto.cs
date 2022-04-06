using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class SemDesconto: Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            return 0;
        }
        
    }
}
