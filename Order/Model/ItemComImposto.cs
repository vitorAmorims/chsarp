namespace Order.Model
{
    public abstract class ItemComImposto : Item
    {
        public ItemComImposto(string produto, string marca, int preco) : base(produto, marca, preco)
        {

        }

        public double CalcularImposto(System.DateTime dateTime)
        {
            return this.Preco * this.getTaxes(dateTime);
        }
        public abstract double getTaxes(System.DateTime dateTime);
    }
}
