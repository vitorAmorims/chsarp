namespace Templatemethod.src.Model
{
    public class IHIT: TemplateDeImpostoCondicional
    {
        // Crie o imposto IHIT, que tem a seguinte regra: caso existam 2 ítens 
        // com o mesmo nome, o imposto deve ser de 13% mais R$100,00.
        // Caso contrário, o valor do imposto deverá ser 
        // (1% * o número de ítens no orçamento).
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return TemDoisItensNoOrcamento(orcamento);
        }
        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.13) + 100;
        }
        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.01) * orcamento.Itens.Count;
        }
        private bool TemDoisItensNoOrcamento(Orcamento orcamento)
        {
            if(orcamento.Itens.Count == 2 && CompararNome(orcamento))
            {
                return true;
            }
            return false;
        }
        private bool CompararNome(Orcamento orcamento)
        {
            string nome1 = orcamento.Itens[0].Nome;
            string nome2 = orcamento.Itens[1].Nome;
            if(nome1 == nome2) return true;
            return false;
        }
    }
}
