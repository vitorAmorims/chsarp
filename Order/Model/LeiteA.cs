using System;

namespace Order.Model
{
    public class LeiteA: Item
    {
        public LeiteA(string Marca, int Preco):base("Leite A", Marca, Preco)
        {
            
        }

        public override double CalcularImposto()
        {
            return Convert.ToDouble(this.Preco) * 0.1;
        }
    }
}


        // {
        //     var total = 0.0;
        //     if (Produto == "Leite A")
        //     {
        //         total += Convert.ToDouble(Preco) * 0.1;
        //     }
        //     if (Produto == "Cartela de ovos")
        //     {
        //         total += Convert.ToDouble(Preco) * 0.2;
        //     }
        //     if (Produto == "Chocolate em pó")
        //     {
        //         total += Convert.ToDouble(Preco) * 0.3;
        //     }
        //     if (Produto == "Detergente liquido")
        //     {
        //         total += Convert.ToDouble(Preco) * 0.5;
        //     }
        //     return total;
        // }
