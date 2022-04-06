namespace Strategy.src.Model
{
    public class CalculadoraImposto_v2
    {
        public void RealizarCalculoICMS(Orcamento orcamento)
        {
            double icms = new ICMS().Calcula(orcamento);
            System.Console.WriteLine(icms);
        }

        public void RealizarCalculoISS(Orcamento orcamento)
        {
            double icms = new ISS().Calcula(orcamento);
            System.Console.WriteLine(icms);
        }
    }
}
