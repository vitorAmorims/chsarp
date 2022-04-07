namespace ExampleExtensions.src.Model
{
    public class JSON : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if (Formato.JSON.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição em formato JSON");
                return;
            }
            Successor.ProcessRequest(conta, formato);
        }
    }
}
