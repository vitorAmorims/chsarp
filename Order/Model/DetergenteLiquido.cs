using System;

namespace Order.Model
{
    public class DetergenteLiquido : ItemComImposto
    {
        public DetergenteLiquido(string Marca, int Preco) : base("Detergente liquido", Marca, Preco)
        {

        }

        public override double getImposto(System.DateTime dateTime)
        {
            // var data = new DateTime();
            var marco = 3;
            if (dateTime.Month == marco)
            {
                return 0.0;
            }
            return 0.5;
        }
    }
}
