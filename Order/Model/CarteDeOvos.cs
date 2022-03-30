using System;

namespace Order.Model
{
    public class CartelaDeOvos : ItemComImposto
    {
        public CartelaDeOvos(string Marca, int Preco) : base("Cartela de ovos", Marca, Preco)
        {

        }

        public override double getImposto(System.DateTime dateTime)
        {
            return 0.2;
        }
    }
}
