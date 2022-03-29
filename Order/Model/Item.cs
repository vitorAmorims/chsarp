using System;

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

        public double CalcularImposto()
        {
            var total = 0.0;
            if (Produto == "Leite A")
            {
                total += Convert.ToDouble(Preco) * 0.1;
            }
            if (Produto == "Cartela de ovos")
            {
                total += Convert.ToDouble(Preco) * 0.2;
            }
            if (Produto == "Chocolate em pó")
            {
                total += Convert.ToDouble(Preco) * 0.3;
            }
            if (Produto == "Detergente liquido")
            {
                total += Convert.ToDouble(Preco) * 0.5;
            }
            return total;
        }
    }
}
