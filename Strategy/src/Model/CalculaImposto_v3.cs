using Strategy.src.Interface;

namespace Strategy.src.Model
{
    public class CalculaImposto_v3
    {
        public double RealizarCalculo(Orcamento orcamento, Imposto imposto)
        {
            double valor = imposto.Calcula(orcamento);
            System.Console.WriteLine(valor);
            return valor;
        }
    }
}
