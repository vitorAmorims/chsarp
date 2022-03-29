namespace Order.Model
{
    public class Item
    {
        public Item(string produto, string marca, int preco)
        {
            this.Produto = produto;
            this.Marca = marca;
            this.Preco = preco;

        }
        public string Produto { get; set; }
        public string Marca { get; set; }
        public int Preco { get; set; }
    }
}
