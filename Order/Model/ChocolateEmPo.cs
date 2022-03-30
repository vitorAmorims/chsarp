using System;

namespace Order.Model
{
    public class ChocolateEmPo: ItemComImposto
    {
        public ChocolateEmPo(string Marca, int Preco):base("Chocolate em pó", Marca, Preco)
        {
            
        }

        public override double getTaxes(System.DateTime dateTime)
        {
            return 0.3;
        }
    }
}
