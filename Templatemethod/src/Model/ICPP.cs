namespace Templatemethod.src.Model
{
    public class ICPP : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }
        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }
        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
        //primeiro
        // public double Calcula(Orcamento orcamento)
        // {
        //     if (orcamento.Valor >= 500)
        //     {
        //         return orcamento.Valor * 0.07;
        //     }
        //     else
        //     {
        //         return orcamento.Valor * 0.05;
        //     }
        // }
    }
}
