using System;
namespace ExampleExtensions.src.Model
{
    public class Porcentagem : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if(Formato.PORCENTO.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição em formato arquivo.CSV separador %");
                return;
            }
            Successor.ProcessRequest(conta, formato);
        }
    }
}
