using ContaBancaria.src.Interface;

namespace ContaBancaria.src.Model
{
    public class RealizadorDeInvestimentos
    {
        public double RealizaCalculoInvestimento(Conta conta, Investimento investimento)
        {
            double valor = investimento.Calcula(conta);
            System.Console.WriteLine(valor);
            return valor;
        }
    }
}
