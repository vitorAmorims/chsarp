using ContaBancaria.src.Interface;

namespace ContaBancaria.src.Model
{
    public class Conservador : Investimento
    {
        public double Calcula(Conta conta)
        {
            return conta.Saldo * 0.08;
        }
    }
}
