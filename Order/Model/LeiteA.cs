using System;

namespace Order.Model
{
    public class LeiteA: Item
    {
        public LeiteA(string Marca, int Preco):base("Leite A", Marca, Preco)
        {
            
        }

        public override double getTaxes()
        {
            return 0.1;
        }
    }
}

