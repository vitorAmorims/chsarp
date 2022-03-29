using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Model
{
    public class Venda
    {
        public Venda()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

         public List<Item> lista = new List<Item>();

        public int getSubTotal()
        {
            return lista.Sum(x =>
            {
                return x.Preco;
            });
        }

        public double getTaxes()
        {
            var total = 0.0;
            foreach(var item in lista)
            {
                if(item.Produto == "Leite A")
                {
                    total += item.Preco * 0.1;
                }
                if(item.Produto == "Cartela de ovos")
                {
                    total += item.Preco * 0.2;
                }
                if(item.Produto == "Chocolate em pó")
                {
                    total += item.Preco * 0.3;
                }
                if(item.Produto == "Detergente liquido")
                {
                    total += item.Preco * 0.5;
                }
            }
            return total;
        }

        public double getTotal()
        {
            return getSubTotal() + getTaxes();
        }
    }
}
