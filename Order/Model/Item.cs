using System;

namespace Order.Model
{
    public abstract class Item
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

        public double CalcularImposto()
        {
            return this.Preco * this.getTaxes();
        }
        public abstract double getTaxes();
    }
}
