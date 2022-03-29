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
    }
}
