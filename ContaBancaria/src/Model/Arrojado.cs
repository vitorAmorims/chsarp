using System;
using ContaBancaria.src.Interface;

namespace ContaBancaria.src.Model
{
    public class Arrojado : Investimento
    {
        public double Calcula(Conta conta)
        {
            Random rnd = new Random();
            var possibilidade = rnd.Next(10);
            
            if(possibilidade >= 8)
            {
                return conta.Saldo * 0.05;
            }
            if(possibilidade < 8 && possibilidade > 5)
            {
                return conta.Saldo * 0.03;
            }
            return conta.Saldo * 0.6;
        }
    }
}
