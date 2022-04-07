using System;
namespace ExampleExtensions.src.Model
{
    public class XML : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if(Formato.XML.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição co formato XML");
                return;
            }
            Successor.ProcessRequest(conta, formato);
        }
    }
}
