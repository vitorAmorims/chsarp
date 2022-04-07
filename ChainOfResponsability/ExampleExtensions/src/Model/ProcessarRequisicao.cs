namespace ExampleExtensions.src.Model
{
    public class ProcessarRequisicao
    {
        public void ChainOfResponsability(Conta conta, Formato formato)
        {
            Aprovador xml = new XML();
            Aprovador csv = new CSV();
            Aprovador porcentagem = new Porcentagem();
            Aprovador json = new JSON();
            Aprovador extensaoInvalida = new ExtensaoIndefinida();

            xml.SetSuccessor(csv);
            csv.SetSuccessor(porcentagem);
            porcentagem.SetSuccessor(json);
            json.SetSuccessor(extensaoInvalida);

            xml.ProcessRequest(conta, formato);
        }
    }
}
