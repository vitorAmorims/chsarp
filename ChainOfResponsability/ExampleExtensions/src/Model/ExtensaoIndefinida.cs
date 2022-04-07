namespace ExampleExtensions.src.Model
{
    public class ExtensaoIndefinida : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if((Formato.XML != formato) || (Formato.CSV != formato) ||
            (Formato.PORCENTO != formato) || (Formato.JSON != formato))
            {
                System.Console.WriteLine("retorne a requisição com separador correto");
                return;
            }
        }
    }
}
