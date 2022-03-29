using System;

namespace Order.Model
{
    public class DetergenteLiquido:Item
    {
        public DetergenteLiquido(string Marca, int Preco):base("Detergente liquido", Marca, Preco)
        {
            
        }

        public override double getTaxes()
        {
            return 0.5;
        }
    }
}
