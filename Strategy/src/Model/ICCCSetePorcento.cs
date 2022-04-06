using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class ICCCSetePorcento : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if(orcamento.Valor >= 1000 && orcamento.Valor < 3000)
            {
                return orcamento.Valor * 0.07;
            }
            return 0;
        }
    }
}
