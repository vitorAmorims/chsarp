using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class ICCCMeioPorcento : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if(orcamento.Valor < 1000)
            {
                return orcamento.Valor * 0.05;    
            }
            return 0;
        }
    }
}
