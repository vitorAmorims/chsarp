using System;
using System.Text.Json;

namespace ExampleExtensions.src.Model
{
    public class JSON : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if (Formato.JSON.Equals(formato))
            {
                var result = JsonSerializer.Serialize(conta);
                System.Console.WriteLine("retorne a requisição em formato JSON");
                System.Console.WriteLine(result);
                System.Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
            
        }
    }
}
