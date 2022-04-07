namespace ExampleExtensions.src.Model
{
    public abstract class Aprovador
    {
        protected Aprovador Successor;
        public void SetSuccessor(Aprovador successor)
        {
            this.Successor = successor;
        }
        public abstract void ProcessRequest(Conta conta, Formato formato);
    }
}
