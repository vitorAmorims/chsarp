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
            foreach (var item in lista)
            {
                total += item.CalcularImposto();
            }
            return total;
        }

        public double getTotal()
        {
            return getSubTotal() + getTaxes();
        }
    }
}
