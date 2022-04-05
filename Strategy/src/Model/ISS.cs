using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class ISS : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        // public double CalculaISS(Orcamento orcamento)
        // {
        //     return orcamento.Valor * 0.06;
        // }
    }
}
