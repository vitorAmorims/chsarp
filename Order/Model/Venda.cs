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

        public List<ItemComImposto> lista = new List<ItemComImposto>();

        public int getSubTotal()
        {
            return lista.Sum(x =>
            {
                return x.Preco;
            });
        }

        public double getTaxes(DateTime dateTime)
        {
            var total = 0.0;
            foreach (var i in lista)
            {
                total += i.CalcularImposto(dateTime);
            }
            return total;
        }

        public double getTotal(DateTime dateTime)
        {
            return getSubTotal() + getTaxes(dateTime);
        }
    }
}
