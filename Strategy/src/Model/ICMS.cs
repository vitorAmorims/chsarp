using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class ICMS : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.05) + 50;
        }
    }
}
