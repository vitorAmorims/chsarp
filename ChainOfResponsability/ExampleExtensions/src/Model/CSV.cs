using System;
namespace ExampleExtensions.src.Model
{
    public class CSV : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if(Formato.CSV.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição em formato arquivo.CSV");
                return;
            }
            Successor.ProcessRequest(conta, formato);
        }
    }
}
