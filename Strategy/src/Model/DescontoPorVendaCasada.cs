using Strategy.src.Interface;
using System.Linq;

namespace Strategy.src.Model
{
    public class DescontoPorVendaCasada : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            // if (orcamento.Itens.Any(i => (i.Nome == "caneta")
            //     && (i.Nome == "lapis")))
            // {
            //     return orcamento.Valor * 0.05;
            // }
            if(Existe("caneta", orcamento) && Existe("lapis", orcamento))
            {
                return orcamento.Valor * 0.05;
            }

            return Proximo.Desconta(orcamento);
        }
        private bool Existe(string nomeDoItem, Orcamento orcamento)
        {
            foreach (Item item in orcamento.Itens)
            {
                if (item.Nome.Equals(nomeDoItem))
                    return true;
            }
            return false;
        }
    }
}
