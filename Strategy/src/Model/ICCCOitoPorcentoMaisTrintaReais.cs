using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class ICCCOitoPorcentoMaisTrintaReais : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if(orcamento.Valor >= 3000)
            {
                return (orcamento.Valor * 0.08) + 30;
            }
            return 0;
        }
    }
}
