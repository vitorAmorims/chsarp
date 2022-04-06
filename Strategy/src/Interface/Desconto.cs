using Strategy.src.Model;

namespace Strategy.src.Interface
{
    public interface Desconto
    {
        double Desconta(Orcamento orcamento);
        Desconto Proximo { get; set; }
    }
}
