namespace Order.Model
{
    public abstract class ItemComImposto : Item
    {
        public ItemComImposto(string produto, string marca, int preco) : base(produto, marca, preco)
        {

        }

        public double CalcularImposto()
        {
            return this.Preco * this.getTaxes();
        }
        public abstract double getTaxes();
    }
}
