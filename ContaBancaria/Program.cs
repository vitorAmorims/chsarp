using System;
using ContaBancaria.src.Model;

namespace ContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Conservador conservador = new Conservador();  
            Moderado moderado = new Moderado();
            Arrojado arrojado = new Arrojado();

            Conta contaConservador = new Conta("ClienteFake", 100);
            var resultadoC = conservador.Calcula(contaConservador);
            System.Console.WriteLine(resultadoC);
            contaConservador.Deposito(resultadoC);
            System.Console.WriteLine(contaConservador.Saldo);

            System.Console.WriteLine("-----------------------");
            
            Conta contaModerado = new Conta("ClienteFake", 100);
            var resultadoM = moderado.Calcula(contaModerado);
            System.Console.WriteLine(resultadoM);
            contaModerado.Deposito(resultadoM);
            System.Console.WriteLine(contaConservador.Saldo);

            System.Console.WriteLine("------------------------");

            Conta contaArrojado = new Conta("ClienteFake", 100);
            var resultadoA = arrojado.Calcula(contaArrojado);
            System.Console.WriteLine(resultadoA);
            contaArrojado.Deposito(resultadoA);
            System.Console.WriteLine(contaArrojado.Saldo);

        }
    }
}
