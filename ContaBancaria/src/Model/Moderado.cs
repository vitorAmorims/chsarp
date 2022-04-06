using System;
using ContaBancaria.src.Interface;

namespace ContaBancaria.src.Model
{
    public class Moderado : Investimento
    {
        public double Calcula(Conta conta)
        {
            Random rnd = new Random();
            var possibilidade = rnd.Next(10);
            
            if(possibilidade >= 6)
            {
                return conta.Saldo * 0.07;
            }
            return conta.Saldo * 0.025;
        }
    }
}
