using System;

namespace ContaBancaria.src.Model
{
    public class Conta
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }

        public Conta(string nome, double saldo)
        {
            this.Nome = nome;
            this.Saldo = saldo;
        }

        public void Saque(double saque)
        {
            if(this.Saldo < saque)
            {
                throw new Exception("O valor do saque, é maior que o saldo");
            }
            this.Saldo -= saque;
        }

        public void Deposito(double valor)
        {
            this.Saldo += valor * 0.75; 
        }
    }
}
