using System;
using ExampleExtensions.src.Model;

namespace ExampleExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta = new Conta("userFaker", 1000);
            ProcessarRequisicao processarRequisicao = new ProcessarRequisicao();
            processarRequisicao.ChainOfResponsability(conta, Formato.PORCENTO);
            processarRequisicao.ChainOfResponsability(conta, Formato.CSV);
            processarRequisicao.ChainOfResponsability(conta, Formato.XML);
            processarRequisicao.ChainOfResponsability(conta, Formato.JSON);
            


            
        }
    }
}
