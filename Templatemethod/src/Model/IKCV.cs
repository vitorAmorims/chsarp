namespace Templatemethod.src.Model
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return TemItemMaiorQue100ReaisNo(orcamento);
        }
        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.10;
        }
        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        private bool TemItemMaiorQue100ReaisNo(Orcamento orcamento)
        {
            foreach (Item item in orcamento.Itens)
            {
                if (item.Valor > 100) return true;
            }
            return false;
        }

        // public double Calcula(Orcamento orcamento)
        // {
        //     if (orcamento.Valor > 500 && TemItemMaiorQue100ReaisNo(orcamento))
        //     {
        //         return orcamento.Valor * 0.10;
        //     }
        //     else
        //     {
        //         return orcamento.Valor * 0.06;
        //     }
        // }

        // private bool TemItemMaiorQue100ReaisNo(Orcamento orcamento)
        // {
        //     foreach (Item item in orcamento.Itens)
        //     {
        //         if (item.Valor > 100) return true;
        //     }
        //     return false;
        // }
    }
}
