using System;

namespace Order.Model
{
    public class CartelaDeOvos: Item
    {
        public CartelaDeOvos(string Marca, int Preco):base("Cartela de ovos", Marca, Preco)
        {
            
        }

        public override double CalcularImposto()
        {
            return Convert.ToDouble(this.Preco) * 0.2;
        }
    }
}
